using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class WeightDimension
    {
        /// <summary>
        /// Specifies the units of the provided value
        /// </summary>
        [JsonProperty("unit")]
        public WeightUnit Unit { get; set; }

        /// <summary>
        /// The amount of the provided unit that, together,describes a weight
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public enum WeightUnit
    {
        KILOGRAM,
        POUND
    }
}