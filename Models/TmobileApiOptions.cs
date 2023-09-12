namespace TMobile.Api.Models
{
    public class TmobileApiOptions
    {
        public TmobileApiOptions()
        {
            
        }
        public string FernetEncryptionKey { get; set; } = "afIqRZm6iSev4zWysNGAjR6fCrOMf5GQqhKFfmXkgOU=";
        public string OauthClientKey { get; set; } = "9havvat6hm0b962i";
        public string BaseDomain { get; set; } = "odido.nl";
        public string UserAgent { get; set; } = "ODIDO 8.0.0 (Android 12; 12)";


        public readonly static TmobileApiOptions OdidoApiOptions = new TmobileApiOptions()
        {
            FernetEncryptionKey = "afIqRZm6iSev4zWysNGAjR6fCrOMf5GQqhKFfmXkgOU",
            OauthClientKey = "9havvat6hm0b962i",
            BaseDomain = "odido.nl",
            UserAgent = "ODIDO 8.0.0 (Android 12; 12)"
        };
    }
}