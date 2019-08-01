using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Order
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("orderNumber")] public string OrderNumber { get; set; }

        [JsonProperty("createdOn")] public DateTime CreatedOn { get; set; }

        [JsonProperty("modifiedOn")] public DateTime ModifiedOn { get; set; }

        [JsonProperty("testmode")] public bool TestMode { get; set; }

        [JsonProperty("customerEmail")] public string CustomerEmail { get; set; }

        [JsonProperty("billingAddress")] public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shippingAddress")] public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("fulfillmentStatus")] public string FulfillmentStatus { get; set; }

        [JsonProperty("lineItems")] public List<LineItem> LineItems { get; set; }

        [JsonProperty("internalNotes")] public List<InternalNote> InternalNotes { get; set; }

        [JsonProperty("shippingLines")] public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("discountLines")] public List<DiscountLine> DiscountLines { get; set; }

        [JsonProperty("formSubmission")] public List<FormSubmission> FormSubmission { get; set; }

        [JsonProperty("fulfillments")] public List<Fulfillment> Fulfillments { get; set; }

        [JsonProperty("subtotal")] public Subtotal Subtotal { get; set; }

        [JsonProperty("shippingTotal")] public ShippingTotal ShippingTotal { get; set; }

        [JsonProperty("discountTotal")] public DiscountTotal DiscountTotal { get; set; }

        [JsonProperty("taxTotal")] public TaxTotal TaxTotal { get; set; }

        [JsonProperty("refundedTotal")] public RefundedTotal RefundedTotal { get; set; }

        [JsonProperty("grandTotal")] public GrandTotal GrandTotal { get; set; }
    }
}