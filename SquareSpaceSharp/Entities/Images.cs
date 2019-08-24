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
    }
}