using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class WeightDimension
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}