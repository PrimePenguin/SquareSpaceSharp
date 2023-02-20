using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Profile
    {
        /// <summary>
        /// The profile's system identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Profile first name.
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Profile last name.
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Profile email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///  Indicates whether the profile has an account with the website.
        /// </summary>
        [JsonProperty("hasAccount")]
        public bool HasAccount { get; set; }

        /// <summary>
        /// Indicates whether the profile has any commerce orders or donations with the website.
        /// </summary>
        [JsonProperty("isCustomer")]
        public bool CustomerEmail { get; set; }

        /// <summary>
        /// ISO 8601 UTC date and time string; represents when the profile was created.
        /// </summary>
        [JsonProperty("createdOn")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// Profile’s address.
        /// An approximate address for the user based on existing data;
        /// it should not be used for shipping or billing purposes.
        /// Field is `null` if an approximate address can't be determined.
        /// </summary>
        [JsonProperty("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Indicates whether the profile opted to receive marketing.
        /// </summary>
        [JsonProperty("acceptsMarketing")]
        public bool AcceptsMarketing { get; set; }

       /// <summary>
       /// Summary of profile’s commerce transactions.
       /// If a profile has no commerce transactions, the object is still returned with `null` or `0` values.
       /// This information is calculated asynchronously; there may be a slight delay between 
       /// when an order is created, and when it's reflected in the object. 
        /// </summary>
        [JsonProperty("transactionsSummary")]
        public TransactionsSummary TransactionSummary { get; set; }

    }
}