using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class CurrencyValue
    {
        /// <summary>
        /// Monetary amount.
        /// </summary>
        [JsonProperty("value")] public string Value { get; set; }

        /// <summary>
        /// ISO 4217 currency code string.
        /// </summary>
        [JsonProperty("currency")] public string Currency { get; set; }
    }
}