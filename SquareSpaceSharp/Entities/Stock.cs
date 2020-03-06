using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Stock
    {
        /// <summary>
        /// Indicates whether stock is currently tracked for this variant.
        /// </summary>
        [JsonProperty("unlimited")]
        public bool IsUnlimited { get; set; }

        /// <summary>
        /// The current amount in stock, or the last known amount in stock prior to becoming unlimited. This value is modified by purchases and returns only if the variant is not unlimited.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}