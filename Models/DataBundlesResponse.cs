using Newtonsoft.Json;

namespace TMobile.Api.Models
{
    public class DataBundlesResponse
    {
        public int GetRemainingMB(string countryCode = "NL") {
          return Convert.ToInt32(Bundles.Where(o => o.Zones.Contains(countryCode)).Sum(b => b.Remaining.Value) / 1024);
        }

        [JsonProperty("Location")]
        public LocationC Location { get; set; }

        [JsonProperty("NextReset")]
        public string NextReset { get; set; }

        [JsonProperty("BalanceDate")]
        public string BalanceDate { get; set; }

        [JsonProperty("IsInBlockRedirect")]
        public bool IsInBlockRedirect { get; set; }

        [JsonProperty("AllowedToUseRoamingPasses")]
        public bool AllowedToUseRoamingPasses { get; set; }

        [JsonProperty("Bundles")]
        public List<Bundle> Bundles { get; set; }

        [JsonProperty("RoamingTariffText")]
        public string RoamingTariffText { get; set; }

        public class LocationC
        {
            [JsonProperty("Zone")]
            public string Zone { get; set; }

            [JsonProperty("ZoneColor")]
            public string ZoneColor { get; set; }

            [JsonProperty("Country")]
            public string Country { get; set; }

            [JsonProperty("CountryCode")]
            public string CountryCode { get; set; }
        }

        public class Bundle
        {
            [JsonProperty("Zones")]
            public List<string> Zones { get; set; }

            [JsonProperty("BuyingCode")]
            public string BuyingCode { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            [JsonProperty("StartDate")]
            public string StartDate { get; set; }

            [JsonProperty("ExpirationDate")]
            public string ExpirationDate { get; set; }

            [JsonProperty("IsUnlimited")]
            public bool IsUnlimited { get; set; }

            [JsonProperty("Limit")]
            public Limit Limit { get; set; }

            [JsonProperty("Used")]
            public Used Used { get; set; }

            [JsonProperty("Remaining")]
            public Remaining Remaining { get; set; }

            [JsonProperty("SortOrder")]
            public string SortOrder { get; set; }

            [JsonProperty("IsSpeedStepDown")]
            public bool IsSpeedStepDown { get; set; }

            [JsonProperty("IsRoamingDataRoamLikeHome")]
            public bool IsRoamingDataRoamLikeHome { get; set; }

            [JsonProperty("UsageIsAvailable")]
            public bool UsageIsAvailable { get; set; }

            [JsonProperty("IsDayBundle")]
            public bool IsDayBundle { get; set; }

            [JsonProperty("IsSsdPass")]
            public bool IsSsdPass { get; set; }

            [JsonProperty("DoNotSumInOverview")]
            public bool DoNotSumInOverview { get; set; }

            [JsonProperty("IsFlexCaps")]
            public bool IsFlexCaps { get; set; }

            [JsonProperty("ZoneColor")]
            public string ZoneColor { get; set; }

            [JsonProperty("BundleCode")]
            public string BundleCode { get; set; }

            [JsonProperty("BucketCode")]
            public string BucketCode { get; set; }

            [JsonProperty("IsUnlimitedFullSpeed")]
            public bool IsUnlimitedFullSpeed { get; set; }

            [JsonProperty("OverrulesAlways")]
            public bool OverrulesAlways { get; set; }

            [JsonProperty("ActiveFrom")]
            public string ActiveFrom { get; set; }

            [JsonProperty("ActiveTo")]
            public string ActiveTo { get; set; }
        }

        public class Limit
        {
            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("Value")]
            public int Value { get; set; }

            [JsonProperty("Presentation")]
            public string Presentation { get; set; }
        }

        public class Used : Limit { }

        public class Remaining : Limit { }
    }

}
