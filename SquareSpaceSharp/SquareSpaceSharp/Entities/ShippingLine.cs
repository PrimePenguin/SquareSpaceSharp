using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class ShippingLine
    {
        [JsonProperty("method")] public string Method { get; set; }

        [JsonProperty("amount")] public Amount Amount { get; set; }
    }
}