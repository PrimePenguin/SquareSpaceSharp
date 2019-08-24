using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class VariantPricing
    {
        /// <summary>
        /// Base Price
        /// </summary>
        [JsonProperty("basePrice")]
        public CurrencyValue BasePrice { get; set; }

        /// <summary>
        /// Sale Price
        /// </summary>
        [JsonProperty("salePrice")]
        public CurrencyValue SalePrice { get; set; }

        /// <summary>
        /// A flag indicating whether this product is on sale
        /// </summary>
        [JsonProperty("onSale")]
        public bool OnSale { get; set; }
    }
}