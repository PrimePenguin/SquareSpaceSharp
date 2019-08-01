using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Fulfillment
    {
        [JsonProperty("carrierName")] public string CarrierName { get; set; }

        [JsonProperty("trackingNumber")] public string TrackingNumber { get; set; }

        [JsonProperty("trackingUrl")] public string TrackingUrl { get; set; }
    }
}