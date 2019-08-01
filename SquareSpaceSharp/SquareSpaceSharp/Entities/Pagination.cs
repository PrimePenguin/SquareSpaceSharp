using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Pagination
    {
        /// <summary>
        /// a flag indicating whether another page of order data is available.
        /// </summary>
        [JsonProperty("hasNextPage")]
        public bool HasNextPage { get; set; }

        /// <summary>
        /// the cursor that would be used in a subsequent request to retrieve the next page of data.
        /// </summary>
        [JsonProperty("nextPageCursor")]
        public string NextPageCursor { get; set; }

        /// <summary>
        /// a pre-built URL that applications can use to automatically request the next page of data.
        /// </summary>
        [JsonProperty("nextPageUrl")]
        public string NextPageUrl { get; set; }
    }
}