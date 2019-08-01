using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Inventory
    {
        [JsonProperty("variantId")] public string VariantId { get; set; }

        [JsonProperty("sku")] public string Sku { get; set; }

        [JsonProperty("descriptor")] public string Descriptor { get; set; }

        [JsonProperty("isUnlimited")] public bool IsUnlimited { get; set; }

        [JsonProperty("quantity")] public int Quantity { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("result")] public List<Inventory> Inventory { get; set; }
    }
}
