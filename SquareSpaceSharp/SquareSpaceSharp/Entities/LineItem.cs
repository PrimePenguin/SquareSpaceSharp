using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class LineItem
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("variantId")] public string VariantId { get; set; }

        [JsonProperty("sku")] public string Sku { get; set; }

        [JsonProperty("productId")] public string ProductId { get; set; }

        [JsonProperty("productName")] public string ProductName { get; set; }

        [JsonProperty("quantity")] public int Quantity { get; set; }

        [JsonProperty("unitPricePaid")] public UnitPricePaid UnitPricePaid { get; set; }

        [JsonProperty("variantOptions")] public List<VariantOption> VariantOptions { get; set; }

        [JsonProperty("customizations")] public object Customizations { get; set; }

        [JsonProperty("imageUrl")] public string ImageUrl { get; set; }
    }
}