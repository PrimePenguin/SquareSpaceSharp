using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class DiscountLine
    {
        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("amount")] public CurrencyValue Amount { get; set; }

        [JsonProperty("promoCode")] public string PromoCode { get; set; }
    }
}