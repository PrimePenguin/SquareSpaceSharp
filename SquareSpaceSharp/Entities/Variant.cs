using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Variant
    {
        /// <summary>
        /// An identifier assigned to the variant at the time it was created. These ids are the same as those referenced in the variantId field of the Inventory API
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A store-specific identifier enforced as unique within variants of the same product, but not across multiple products.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        ///  Provides pricing information including the unit’s base price, sale price, and a flag indicating whether the product is currently on sale
        /// </summary>
        [JsonProperty("pricing")]
        public VariantPricing Pricing { get; set; }

        /// <summary>
        ///  A set of custom key-value string pairs representing all of the features that make this particular product variant unique.
        /// Values are often things like color, design, and weight, but may represent any information the merchant has deemed a defining characteristic of the variant.
        /// </summary>
        [JsonProperty("attributes")]
        public IDictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///  The weight and size to use when calculating shipping.The units can be imperial(INCH, POUND) or metric (CENTIMETER, KILOGRAM).
        /// </summary>
        [JsonProperty("shippingMeasurements")]
        public ShippingDimension ShippingMeasurements { get; set; }

        /// <summary>
        /// This variant’s main image. The data contained here provides the same information and features as the product’s images attribute
        /// </summary>
        [JsonProperty("image")]
        public Images Image { get; set; }
    }
}