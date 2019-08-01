using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class InventoryCollection
    {
        [JsonProperty("inventory")] public IEnumerable<Inventory> Inventories { get; set; }

        [JsonProperty("pagination")] public Pagination Pagination { get; set; }
    }
}
