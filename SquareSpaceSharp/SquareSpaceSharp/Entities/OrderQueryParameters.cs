using Newtonsoft.Json;
using SquareSpaceSharp.Infrastructure;

namespace SquareSpaceSharp.Entities
{
    public class OrderQueryParameters : Parameterizable
    {
        /// <summary>
        /// Type: A string token, returned from the pagination.nextPageCursor of a previous response.Identifies where the next page of results should begin.If this parameter is not present or empty, the first page of order data will be returned.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        /// <summary>
        /// optional, required when modifiedBefore is present, Type: An ISO 8601 date and time string, e.g. 2016-04-10T12:00:00Z.
        ///Time-boxes request to orders that were modified after this time.
        /// </summary>
        [JsonProperty("modifiedAfter")]
        public string ModifiedAfter { get; set; }

        /// <summary>
        ///  optional, required when modifiedAfter is present, Type: An ISO 8601 date and time string.
        ///Time-boxes request to orders that were modified before this time.
        /// </summary>
        [JsonProperty("modifiedBefore")]
        public string ModifiedBefore { get; set; }

        /// <summary>
        /// Type: An enumerated string value of PENDING, FULFILLED, or CANCELED.
        ///Used to filter orders according to their fulfillment status.
        /// </summary>
        [JsonProperty("fulfillmentStatus")]
        public string FulfillmentStatus { get; set; }
    }
}