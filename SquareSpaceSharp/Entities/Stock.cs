using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Stock
    {
        /// <summary>
        /// Indicates whether the variant has unlimited stock.
        /// </summary>
        [JsonProperty("unlimited")]
        public bool IsUnlimited { get; set; }

        /// <summary>
        /// Number of units that can be purchased.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}