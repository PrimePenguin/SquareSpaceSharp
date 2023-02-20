using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SquareSpaceSharp.Infrastructure;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SquareSpaceSharp.Entities
{
    public class ProfileQueryParameters : Parameterizable
    {
        /// <summary>
        /// Type: A string token, returned from the pagination.nextPageCursor of a previous response.Identifies where the next page of results should begin.If this parameter is not present or empty, the first page of order data will be returned.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        /// <summary>
        /// optional, values include "isCustomer" and/or "hasAccount", or "Email". 
        /// The "email" filter cannot be used with "isCUstomer" or "hasAccount"
        /// Semicolon separated list used to filter profile results:
        /// isCustomer: Value must be true; false currently not supported
        /// hasAccount: Value must be true; false currently not supported
        /// email: Valid email address with URL-encoded characters; case insensitive
        /// filter=isCustomer,true;hasAccount,true
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }

        /// <summary>
        ///  optional, values include: asc or dsc
        /// Identifies the sort direction of the result list; asc for ascending or dsc for descending.
        /// If parameter is not specified, the returned list is in descending order by sortField or by profile id if sortField is not specified.
        /// </summary>
        [JsonProperty("sortDirection")]
        public string SortDirection { get; set; }

        /// <summary>
        /// optional; values include: createdOn, id, email, or lastName
        /// Identifies the sort field of the result list:
        /// id: Unique id of a Profile
        /// lastName: Last name of a profile
        /// createdOn: ISO 8601 UTC date and time when a profile was created
        /// email: Email address of a profile
        /// </summary>
        [JsonProperty("sortField")]
        public string FulfillmentStatus { get; set; }
    }
}