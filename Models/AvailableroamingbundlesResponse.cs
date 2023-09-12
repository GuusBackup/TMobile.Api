using Newtonsoft.Json;

namespace TMobile.Api.Models
{
    public class AvailableroamingbundlesResponse
    {
        [JsonProperty("Bundles")]
        public List<Bundle> Bundles { get; set; }

        public class Bundle
        {
            [JsonProperty("Zones")]
            public List<string> Zones { get; set; }

            [JsonProperty("BundleCode")]
            public string BundleCode { get; set; }

            [JsonProperty("BuyingCode")]
            public string BuyingCode { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            [JsonProperty("Size")]
            public int Size { get; set; }

            [JsonProperty("SizePresentation")]
            public string SizePresentation { get; set; }

            [JsonProperty("SpeedStepDown")]
            public object SpeedStepDown { get; set; }

            [JsonProperty("OriginalPriceExclVat")]
            public decimal OriginalPriceExclVat { get; set; }

            [JsonProperty("OriginalPriceExclVatPresentation")]
            public string OriginalPriceExclVatPresentation { get; set; }

            [JsonProperty("OriginalPriceInclVat")]
            public decimal OriginalPriceInclVat { get; set; }

            [JsonProperty("OriginalPriceInclVatPresentation")]
            public string OriginalPriceInclVatPresentation { get; set; }

            [JsonProperty("PriceExclVat")]
            public decimal PriceExclVat { get; set; }

            [JsonProperty("PriceExclVatPresentation")]
            public string PriceExclVatPresentation { get; set; }

            [JsonProperty("PriceInclVat")]
            public decimal PriceInclVat { get; set; }

            [JsonProperty("PriceInclVatPresentation")]
            public string PriceInclVatPresentation { get; set; }

            [JsonProperty("HasDiscount")]
            public bool HasDiscount { get; set; }

            [JsonProperty("IsRecurring")]
            public bool IsRecurring { get; set; }

            [JsonProperty("IsPayForUse")]
            public bool IsPayForUse { get; set; }

            [JsonProperty("ValidityInHours")]
            public object ValidityInHours { get; set; }

            [JsonProperty("ValidUntil")]
            public object ValidUntil { get; set; }

            [JsonProperty("SortOrder")]
            public string SortOrder { get; set; }

            [JsonProperty("IsSsdPass")]
            public bool IsSsdPass { get; set; }

            [JsonProperty("BuyingCodeAliases")]
            public List<string> BuyingCodeAliases { get; set; }

            [JsonProperty("IsDayBundle")]
            public bool IsDayBundle { get; set; }
        }
    }
}