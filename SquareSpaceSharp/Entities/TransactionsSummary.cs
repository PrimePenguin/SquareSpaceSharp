using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class TransactionsSummary
    {
        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the profile’s first order was submitted.
        /// </summary>
        [JsonProperty("firstOrderSubmittedOn")] 
        public string FirstOrderSubmittedOn { get; set; }

        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the profile’s last order was submitted.
        /// </summary>
        [JsonProperty("lastOrderSubmittedOn")]
        public string LastOrderSubmittedOn { get; set; }


        /// <summary>
        /// Count of orders submitted.
        /// </summary>
        [JsonProperty("orderCount")]
        public int OrderCount { get; set; }

        /// <summary>
        /// Monetary amount with 1,000,000 limit and no markers for the dollar amount. 
        // Conforms to the selected ISO currency's precision. 
        // (E.g., JPY uses 123, but USD uses 123.00 or 123.)      
        /// </summary>
        [JsonProperty("totalOrderAmount")]
        public CurrencyValue TotalOrderAmount { get; set; }

        /// <summary>
        /// Total of all order refunds.        
        /// </summary>
        [JsonProperty("totalRefundAmount")]
        public CurrencyValue TotalRefundAmount { get; set; }


        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the profile’s first donation was submitted.
        /// </summary>
        [JsonProperty("firstDonationSubmittedOn")]
        public string FirstDonationSubmittedOn { get; set; }

        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the profile’s latest donation was submitted.
        /// </summary>
        [JsonProperty("lastDonationSubmittedOn")]
        public string LastDonationSubmittedOn { get; set; }


        /// <summary>
        /// Count of donations submitted.
        /// </summary>
        [JsonProperty("donationCount")]
        public int DonationCount { get; set; }

        /// <summary>
        /// Total of all order refunds.        
        /// </summary>
        [JsonProperty("totalDonationAmount")]
        public CurrencyValue TotalDonationAmount { get; set; }
    }
}