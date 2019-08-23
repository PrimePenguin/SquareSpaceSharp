using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Inventory
    {
        /// <summary>
        /// The identifier for the variant backing the inventory item's information.
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// A custom code assigned to a product variant by a Squarespace merchant for the purposes of stock keeping.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        ///  A generated description using the product’s title and any available variant parameters including, but not limited to, color and size.
        /// </summary>
        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }

        /// <summary>
        /// Indicates whether stock is currently tracked for this variant.
        /// </summary>
        [JsonProperty("isUnlimited")]
        public bool IsUnlimited { get; set; }

        /// <summary>
        /// The current amount in stock, or the last known amount in stock prior to becoming unlimited. This value is modified by purchases and returns only if the variant is not unlimited.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
