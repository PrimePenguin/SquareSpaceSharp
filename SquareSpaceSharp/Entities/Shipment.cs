using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Shipment
    {
        /// <summary>
        /// The ISO 8601 date and time representing the moment the shipment
        /// </summary>
        [JsonProperty("shipDate")]
        public string ShipDate { get; set; }

        /// <summary>
        /// A string representing the parcel service transporting the shipment.
        /// </summary>
        [JsonProperty("carrierName")]
        public string CarrierName { get; set; }

        /// <summary>
        /// A string representing the level of service, as offered by the carrier, used for this shipment.
        /// </summary>
        [JsonProperty("service")]
        public string Service { get; set; }

        /// <summary>
        /// A string representing the carrier-generated tracking number.
        /// </summary>
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Optional A tracking URL, ideally supplied by the carrier. If this value is provided, it must represent a valid URL.
        /// </summary>
        [JsonProperty("trackingUrl")]
        public string TrackingUrl { get; set; }
    }
}