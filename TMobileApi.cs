using Cryptography;
using Newtonsoft.Json;
using System.Text;
using System.Web;
using TMobile.Api.Models;

namespace TMobile.Api
{
    public class TMobileApi
    {
        private HttpClient _httpClient;
        private TmobileApiOptions _options;
        private string oauthToken;

        private string CapiUrl => $"https://capi.{_options.BaseDomain}";

        public TMobileApi(TmobileApiOptions tmobileApiOptions)
        {
            _options = tmobileApiOptions;
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;
            _httpClient = new HttpClient(httpClientHandler);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(tmobileApiOptions.UserAgent);
        }

        public string GetLoginUrl()
        {
            string encrypted_oauth_clientkey = Fernet.Encrypt(_options.FernetEncryptionKey, _options.OauthClientKey);
            return $"https://www.{_options.BaseDomain}/login?returnSystem=app&nav=off&token={encrypted_oauth_clientkey}";
        }

        public string GetRefreshToken(string urlOrToken)
        {
            var encryptedLoginResponse = "";
            if (urlOrToken.Contains("http"))
            {
                encryptedLoginResponse = HttpUtility.ParseQueryString(new Uri(urlOrToken).Query)["token"];
            }
            else
            {
                encryptedLoginResponse = urlOrToken;
            }
            var fernetResultDecrypted = Fernet.Decrypt(_options.FernetEncryptionKey, encryptedLoginResponse);
            var fernetResult = JsonConvert.DeserializeObject<LoginResponse>(fernetResultDecrypted);

            var refreshToken = Fernet.Decrypt(_options.FernetEncryptionKey, fernetResult.AccessToken);

            return refreshToken;
        }

        public async Task<string> CreateOAuthToken(string refreshToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{CapiUrl}/createtoken");
            var payload = new
            {
                AuthorizationCode = refreshToken
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/vnd.capi.tmobile.nl.createtoken.v1+json");
            request.Headers.Add("accept", "application/json,application/vnd.capi.tmobile.nl.createtoken.v1+json");
            request.Headers.Add("authorization", $"Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_options.OauthClientKey}:")));// default: OWhhdnZhdDZobTBiOTYyaTo=
            request.Headers.Add("grant_type", "authorization_code");

            var response = await _httpClient.SendAsync(request);
            if (response.Headers.TryGetValues("Accesstoken", out var headerValues))
                return headerValues.FirstOrDefault();

            return null;
        }

        public async Task<GetResourceResponse> GetApiResource(string resourcelabel = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{CapiUrl}/account/current?resourcelabel={resourcelabel}");
            request.Headers.Add("accept", "application/json,application/vnd.capi.tmobile.nl.account.v1+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");
            var response = await _httpClient.SendAsync(request);

            var responseUrl = response.Headers.Location; // stupid temp way to get the authorization to stick 
            request = new HttpRequestMessage(HttpMethod.Get, responseUrl);
            request.Headers.Add("accept", "application/json,application/vnd.capi.tmobile.nl.account.v1+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");
            response = await _httpClient.SendAsync(request);

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetResourceResponse>(responseData);
        }

        public async Task<LinkedSubscriptionsResponse> GetLinkedSubsriptions()
        {
            var apiResource = (await GetApiResource("LinkedSubscriptions")).Resources.FirstOrDefault();
            var request = new HttpRequestMessage(HttpMethod.Get, apiResource.Url);
            request.Headers.Add("accept", "application/vnd.capi.tmobile.nl.linkedsubscriptions.v1+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");

            var response = await _httpClient.SendAsync(request);
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LinkedSubscriptionsResponse>(responseData);
        }

        public async Task<DataBundlesResponse> GetDataBundles(string subscriptionURL)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, subscriptionURL + "/databundles");
            request.Headers.Add("accept", "application/vnd.capi.tmobile.nl.databundles.v1+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");

            var response = await _httpClient.SendAsync(request);
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DataBundlesResponse>(responseData);
        }

        public async Task<AvailableroamingbundlesResponse> GetAvailableRoamingBundles(string subscriptionURL)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, subscriptionURL + "/availableroamingbundles");
            request.Headers.Add("accept", "application/json,application/vnd.capi.tmobile.nl.roamingbundles.v4+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");

            var response = await _httpClient.SendAsync(request);
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AvailableroamingbundlesResponse>(responseData);
        }

        public async Task<bool> BuyBundle(string subscriptionURL, string buying_code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, subscriptionURL + "/roamingbundles");
            request.Headers.Add("accept", "application/json,application/vnd.capi.tmobile.nl.roamingbundles.v4+json");
            request.Headers.Add("authorization", $"Bearer {oauthToken}");

            var buyPayload = new
            {
                Bundles = new[]
                {
                new
                {
                    BuyingCode = buying_code
                }
            }
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(buyPayload), Encoding.UTF8, "application/vnd.capi.tmobile.nl.roamingbundles.v4+json");
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public void Authenticate(string oauthToken)
        {
            this.oauthToken = oauthToken;
        }


    }
}