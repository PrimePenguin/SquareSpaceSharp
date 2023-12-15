using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Inventory
    {
        /// <summary>
        /// // The product variant id, which also serves as a unique id for the InventoryItem.
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        ///    // Stock keeping unit (SKU) code assigned by the Squarespace merchant for the variant; used to identify an exact variant of a product using a naming scheme preferred by the merchant.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Generated description using the product's title and any available variant attributes including, but not limited to, color and size.
        /// </summary>
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }

        /// <summary>
        /// Indicates whether stock is currently tracked for the item.
        /// </summary>
        [JsonProperty("isUnlimited")]
        public bool IsUnlimited { get; set; }

        /// <summary>
        /// Current amount in stock, or the last known stock amount prior to becoming unlimited. This value is modified by purchases and returns only when `isUnlimited` is `false`.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
