using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Address
    {
        [JsonProperty("firstName")] public string FirstName { get; set; }

        [JsonProperty("lastName")] public string LastName { get; set; }

        [JsonProperty("address1")] public string Address1 { get; set; }

        [JsonProperty("address2")] public string Address2 { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("countryCode")] public string CountryCode { get; set; }

        [JsonProperty("postalCode")] public string PostalCode { get; set; }

        [JsonProperty("phone")] public string Phone { get; set; }
    }
}