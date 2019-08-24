using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class SizeDimension
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("length")]
        public decimal Length { get; set; }

        [JsonProperty("width")]
        public decimal Width { get; set; }

        [JsonProperty("height")]
        public decimal Height { get; set; }
    }
}