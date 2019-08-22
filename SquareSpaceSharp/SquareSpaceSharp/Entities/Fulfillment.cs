using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Fulfillment
    {
        /// <summary>
        /// The name of the shipping company handling the shipment.
        /// </summary>
        [JsonProperty("carrierName")]
        public string CarrierName { get; set; }

        /// <summary>
        /// The shipping company's parcel tracking number.
        /// </summary>
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// The tracking URL for the shipment.
        /// </summary>
        [JsonProperty("trackingUrl")]
        public string TrackingUrl { get; set; }
    }
}