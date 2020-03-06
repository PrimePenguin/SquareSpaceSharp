using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class SizeDimension
    {
        /// <summary>
        /// Specifies the units of the provided values
        /// </summary>
        [JsonProperty("unit")]
        public SizeEnum Unit { get; set; }
        /// <summary>
        /// The length component of the dimensions
        /// </summary>

        [JsonProperty("length")]
        public decimal Length { get; set; }

        /// <summary>
        /// The width component of the dimensions
        /// </summary>
        [JsonProperty("width")]
        public decimal Width { get; set; }

        /// <summary>
        /// The height component of the dimensions
        /// </summary>
        [JsonProperty("height")]
        public decimal Height { get; set; }
    }

    public enum SizeEnum
    {
        CENTIMETER,
        INCH
    }
}