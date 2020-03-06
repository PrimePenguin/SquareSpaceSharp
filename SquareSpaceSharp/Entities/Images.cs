using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Images
    {
        /// <summary>
        /// The full URL of the product’s sales page in the merchant’s store
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// The product image’s id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The dimensions of the image when it was first uploaded, also the dimensions of the image if requested without a format specifier
        /// </summary>
        [JsonProperty("originalSize")]
        public OriginalSize OriginalSize { get; set; }

        /// <summary>
        /// A list of formats that can be used as a query parameter on the ​url​ field to retrieve an image at a certain size, e.g. “?format=100w”.
        /// </summary>
        [JsonProperty("availableFormats")]
        public List<string> AvailableFormats { get; set; }
    }

    public class OriginalSize   
    {
        /// <summary>
        /// The pixel width of an image.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// The pixel height of an image.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}