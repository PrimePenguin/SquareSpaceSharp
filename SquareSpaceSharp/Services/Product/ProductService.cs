using System.Net.Http;
using System.Threading.Tasks;
using SquareSpaceSharp.Entities;
using SquareSpaceSharp.Extensions;
using SquareSpaceSharp.Infrastructure;

namespace SquareSpaceSharp.Services.Product
{
    public class ProductService : SquareSpaceService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProductService" />.
        /// </summary>
        /// <param name="secretApiKey">App Secret Api Key</param>
        public ProductService(string secretApiKey) : base(secretApiKey)
        {
        }

        /// <summary>
        /// Returns collection of Products
        /// </summary>
        /// <param name="cursor">optional Type: A string token, returned from the pagination.nextPageCursor of a previous response.Identifies where the next page of results should begin.If this parameter is not present or empty, the first page of inventory data will be returned.</param>
        public virtual async Task<ProductCollection> GetProductsAsync(string cursor = null)
        {
            var queryParam = string.IsNullOrEmpty(cursor) ? "" : $"?cursor={cursor}";
            var req = PrepareRequest("0.1", $"products{queryParam}");

            return await ExecuteRequestAsync<ProductCollection>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieves product information for specific product ids, useful when information for a few known products is all that is needed.A request can specify up to 50 product ids.The order of the results is not guaranteed.
        /// </summary>
        /// <param name="productIds">A comma-separated list of product ids. Specifies the inventory items to retrieve by product id.</param>
        /// <returns>The <see cref="ProductCollection"/>.</returns>
        public virtual async Task<ProductCollection> GetProductsByIdsAsync(string productIds)
        {
            var req = PrepareRequest("0.1", $"products/{productIds}");

            return await ExecuteRequestAsync<ProductCollection>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Supports stock adjustment operations on specified product variants. Stock adjustments can be incremental, decremental, finite ("I have exactly n of this variant in stock"), or unlimited ("This variant has limitless stock").
        /// </summary>
        /// <param name="stockAdjustmentQuery">Requested Stock adjustment query parameters</param>
        public virtual async Task UpdateStockAdjustment(StockAdjustmentQuery stockAdjustmentQuery)
        {
            var req = PrepareRequest($"inventory/adjustments");
            HttpContent content = null;

            if (stockAdjustmentQuery != null)
            {
                var body = stockAdjustmentQuery.ToDictionary();
                content = new JsonContent(body);
            }
            await ExecuteRequestAsync<object>(req, HttpMethod.Post, content);
        }
    }
}