using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Pagination
    {
        /// <summary>
        /// Flag; indicates whether another page of data is available.
        /// </summary>
        [JsonProperty("hasNextPage")]
        public bool HasNextPage { get; set; }

        /// <summary>
        /// Cursor to use in a subsequent request; retrieves the next page of data.
        /// </summary>
        [JsonProperty("nextPageCursor")]
        public string NextPageCursor { get; set; }

        /// <summary>
        /// a A pre-built URL for applications to request the next page of data.
        /// </summary>
        [JsonProperty("nextPageUrl")]
        public string NextPageUrl { get; set; }
    }
}