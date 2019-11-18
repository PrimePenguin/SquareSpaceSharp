using System.Net.Http;
using System.Threading.Tasks;
using SquareSpaceSharp.Entities;

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
            var req = PrepareRequest("0.1", "products");
            if (!string.IsNullOrEmpty(cursor))
            {
                req.QueryParams.Add("cursor", cursor);
            }

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
    }
}