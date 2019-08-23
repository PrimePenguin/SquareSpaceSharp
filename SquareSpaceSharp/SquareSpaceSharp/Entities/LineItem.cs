using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class LineItem
    {
        /// <summary>
        /// The line item’s system identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The system identifier of the purchased product variant. Value will always be null for digital products.
        /// </summary>
        [JsonProperty("variantId")]
        public string VariantId { get; set; }

        /// <summary>
        /// The SKU of the purchased item.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// The system identifier of the purchased product.
        /// </summary>
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// The name of the purchased product.
        /// </summary>
        [JsonProperty("productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// The amount of this purchased product.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The price the shopper paid per unit of this item.
        /// </summary>
        [JsonProperty("unitPricePaid")]
        public CurrencyValue UnitPricePaid { get; set; }

        /// <summary>
        /// An array of objects representing variant choices made by the shopper, such as “Small, Red” for a t-shirt.
        /// </summary>
        [JsonProperty("variantOptions")]
        public List<VariantOption> VariantOptions { get; set; }

        /// <summary>
        /// An array of objects representing requested customizations, if supported by the item at purchase.
        /// </summary>
        [JsonProperty("customizations")]
        public List<FormSubmission> Customizations { get; set; }

        /// <summary>
        /// The URL to the primary image for this line item.
        /// </summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}