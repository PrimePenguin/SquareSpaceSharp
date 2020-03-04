using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class ShippingDimension
    {
        /// <summary>
        /// Describes the weight of a variant for the purpose of calculating shipping
        /// </summary>
        [JsonProperty("weight")]
        public WeightDimension Weight { get; set; }

        /// <summary>
        /// Describes the dimensions of a variant for the purpose of calculating shipping
        /// </summary>
        [JsonProperty("dimensions")]
        public SizeDimension Dimensions { get; set; }
    }
}