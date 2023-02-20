using System.Net.Http;
using System.Threading.Tasks;
using SquareSpaceSharp.Entities;
using SquareSpaceSharp.Extensions;
using SquareSpaceSharp.Infrastructure;

namespace SquareSpaceSharp.Services.Profile
{
    public class ProfileService : SquareSpaceService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ProfileService" />.
        /// </summary>
        /// <param name="secretApiKey">App Secret Api Key</param>
        public ProfileService(string secretApiKey) : base(secretApiKey)
        {
        }

        /// <summary>
        /// Returns collection of profiles
        /// </summary>
        /// <param name="queryParameters">Order query parameters</param>
        public virtual async Task<ProfileCollection> GetProfilesAsync(OrderQueryParameters queryParameters = null)
        {
            var req = PrepareRequest("profiles",isCommerce:false);

            if (queryParameters != null)
            {
                req.QueryParams.AddRange(queryParameters.ToParameters());
            }

            return await ExecuteRequestAsync<ProfileCollection>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a profiles that match ID.
        /// </summary>
        /// <param name="profileId">Requested profile ID</param>
        /// <returns>The <see cref="Profile"/>.</returns>
        public virtual async Task<ProfileCollection> GetProfilesByIdAsync(string profileId)
        {
            var req = PrepareRequest($"profiles/{profileId}",isCommerce:false);

            return await ExecuteRequestAsync<ProfileCollection>(req, HttpMethod.Get);
        }
    }
}