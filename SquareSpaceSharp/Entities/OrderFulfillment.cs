using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class OrderFulfillment
    {
        /// <summary>
        /// Indicates whether the customer should receive an email notification about the added shipments.
        /// </summary>
        [JsonProperty("shouldSendNotification")]
        public bool ShouldSendNotification { get; set; }

        /// <summary>
        /// An array of objects containing shipment data
        /// </summary>
        [JsonProperty("shipments")]
        public List<Shipment> Shipments { get; set; }
    }
}