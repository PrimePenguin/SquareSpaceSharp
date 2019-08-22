using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class InventoryCollection
    {
        /// <summary>
        /// An array of inventory item objects, which will be empty if the store is not configured with any eligible product variants.
        /// </summary>
        [JsonProperty("inventory")]
        public IEnumerable<Inventory> Inventories { get; set; }

        /// <summary>
        /// An object containing the following fields:
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
