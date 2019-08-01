using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class OrderCollection
    {
        [JsonProperty("result")] public IEnumerable<Order> Orders { get; set; }

        [JsonProperty("pagination")] public Pagination Pagination { get; set; }
    }
}
