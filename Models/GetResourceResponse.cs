using Newtonsoft.Json;

namespace TMobile.Api.Models
{
    public class GetResourceResponse
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("VisitorKeyForExternals")]
        public string VisitorKeyForExternals { get; set; }

        [JsonProperty("IsEligibleForMigration")]
        public bool IsEligibleForMigration { get; set; }

        [JsonProperty("IsCompanyAdmin")]
        public bool IsCompanyAdmin { get; set; }

        [JsonProperty("IsTwoFactorAuthenticationEnabled")]
        public bool IsTwoFactorAuthenticationEnabled { get; set; }

        [JsonProperty("ContactId")]
        public string ContactId { get; set; }

        [JsonProperty("Resources")]
        public List<Resource> Resources { get; set; }
        public class Resource
        {
            [JsonProperty("Label")]
            public string Label { get; set; }

            [JsonProperty("Url")]
            public string Url { get; set; }

            [JsonProperty("Availability")]
            public string Availability { get; set; }
        }
    }

   
}
