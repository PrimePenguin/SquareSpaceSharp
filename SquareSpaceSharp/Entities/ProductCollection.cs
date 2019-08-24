using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class ProductCollection
    {
        /// <summary>
        /// An array containing up to 50 objects of products
        /// </summary>
        [JsonProperty("products")]
        public IEnumerable<Product> Inventories { get; set; }

        /// <summary>
        /// An object containing the following fields:
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
