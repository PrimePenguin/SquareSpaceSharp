using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class ShippingDimension
    {
        [JsonProperty("weight")]
        public WeightDimension Weight { get; set; }

        [JsonProperty("size")]
        public SizeDimension Size { get; set; }
    }
}