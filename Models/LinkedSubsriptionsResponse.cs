using Newtonsoft.Json;


namespace TMobile.Api.Models
{
    public class LinkedSubscriptionsResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }

        public class Subscription
        {
            [JsonProperty("LinkId")]
            public string LinkId { get; set; }

            [JsonProperty("CustomerNumber")]
            public string CustomerNumber { get; set; }

            [JsonProperty("IsFavorite")]
            public bool IsFavorite { get; set; }

            [JsonProperty("MSISDN")]
            public string MSISDN { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("Alias")]
            public object Alias { get; set; }

            [JsonProperty("Role")]
            public string Role { get; set; }

            [JsonProperty("SubscriptionURL")]
            public string SubscriptionURL { get; set; }

            [JsonProperty("ContractType")]
            public string ContractType { get; set; }

            [JsonProperty("CustomerType")]
            public string CustomerType { get; set; }

            [JsonProperty("SubscriptionType")]
            public string SubscriptionType { get; set; }

            [JsonProperty("IsAdmin")]
            public bool IsAdmin { get; set; }

            [JsonProperty("Agreement")]
            public AgreementC Agreement { get; set; }

            [JsonProperty("VisitorKeyForExternals")]
            public string VisitorKeyForExternals { get; set; }

            [JsonProperty("FixedSubscriptionURL")]
            public object FixedSubscriptionURL { get; set; }

            [JsonProperty("Order")]
            public object Order { get; set; }

            public class AgreementC
            {
                [JsonProperty("RateplanName")]
                public string RateplanName { get; set; }

                [JsonProperty("ProductName")]
                public string ProductName { get; set; }

                [JsonProperty("EndDate")]
                public string EndDate { get; set; }

                [JsonProperty("StartDate")]
                public string StartDate { get; set; }

                [JsonProperty("Status")]
                public string Status { get; set; }

                [JsonProperty("RateplanType")]
                public string RateplanType { get; set; }

                [JsonProperty("RenewalEligibilityDate")]
                public string RenewalEligibilityDate { get; set; }

                [JsonProperty("IsPossibleRenewalCandidate")]
                public bool IsPossibleRenewalCandidate { get; set; }

                [JsonProperty("IsAlreadyRenewed")]
                public bool IsAlreadyRenewed { get; set; }

                [JsonProperty("SortOrder")]
                public string SortOrder { get; set; }

                [JsonProperty("ShowOnDashboard")]
                public bool ShowOnDashboard { get; set; }
            }
        }
    }

}
