using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Product
    {
        /// <summary>
        /// An identifier assigned to a product at the time it was created
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of product represented. While Squarespace supports many product types, only physical products are exposed via the Products API at this time.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("storePageId")]
        public string StorePageId { get; set; }

        /// <summary>
        /// The full URL of the product’s sales page in the merchant’s store
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// The product’s name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A long-form description of the product, represented as HTML
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("urlSlug")]
        public string UrlSlug { get; set; }

        /// <summary>
        /// A collection of images associated with the product. Available properties include the URL of the image as hosted on Squarespace,
        /// the image’s original size, and a list of additional sizing options, which are a selection of widths less than or equal to the width of the original image.
        /// To retrieve an image pre-sized to one of the available widths, add format =< available_format > as a query parameter of the provided URL.
        /// </summary>
        [JsonProperty("images")]
        public IEnumerable<Images> Images { get; set; }

        /// <summary>
        /// List of attributes to distinguish variants of the product.
        /// </summary>
        [JsonProperty("variantAttributes")]
        public List<string> VariantAttributes { get; set; }

        /// <summary>
        /// An array of strings providing keywords associated with the product.
        /// </summary>
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// A flag indicating whether this product is currently visible on the merchant’s store
        /// </summary>
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// List of variants of the product.
        /// </summary>
        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }

        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the Product was created.
        /// </summary>
        public string CreatedOn { get; set; }

        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the Product was last modified.
        /// </summary>
        public string ModifiedOn { get; set; }
    }
}
