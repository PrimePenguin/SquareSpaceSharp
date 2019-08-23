using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class OrderCollection
    {
        /// <summary>
        /// An array of order resource objects, which will be empty if the store doesn't have any orders yet.
        /// </summary>
        [JsonProperty("result")]
        public IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// An object containing the following fields:
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
