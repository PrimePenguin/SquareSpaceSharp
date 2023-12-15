using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class InventoryCollection
    {
        /// <summary>
        /// Array of InventoryItem resources. If the merchant site doesn't have any physical or service product variants, this array is empty.
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
