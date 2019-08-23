using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class Order
    {
        /// <summary>
        /// The order's system identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The unique, sequential number of this order.
        /// </summary>
        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The ISO 8601 date and time representation of when this order was created.
        /// </summary>
        [JsonProperty("createdOn")]
        public string CreatedOn { get; set; }

        /// <summary>
        /// The ISO 8601 date and time representation of when this order was last modified
        /// </summary>
        [JsonProperty("modifiedOn")]
        public string ModifiedOn { get; set; }

        /// <summary>
        /// If true, this order is a test order, created using a payment method in test mode
        /// </summary>
        [JsonProperty("testmode")]
        public bool TestMode { get; set; }

        /// <summary>
        /// The email address entered at checkout or, for recurring subscription orders, is the customer's current email address
        /// </summary>
        [JsonProperty("customerEmail")]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The customer’s billing address.
        /// </summary>
        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// The customer’s shipping address
        /// </summary>
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// The current status of the order in the fulfillment workflow. Possible values are: PENDING, FULFILLED, and CANCELED.
        /// </summary>
        [JsonProperty("fulfillmentStatus")]
        public string FulfillmentStatus { get; set; }

        /// <summary>
        /// An array of line item objects that describe what was purchased and how many were purchased, including requested customizations where applicable.
        /// </summary>
        [JsonProperty("lineItems")]
        public List<LineItem> LineItems { get; set; }

        /// <summary>
        /// An array of internal order note objects. Attributes
        /// </summary>
        [JsonProperty("internalNotes")]
        public List<InternalNote> InternalNotes { get; set; }

        /// <summary>
        /// An array of objects detailing chosen shipping options, such as method and cost.
        /// </summary>
        [JsonProperty("shippingLines")]
        public List<ShippingLine> ShippingLines { get; set; }

        /// <summary>
        /// An array of objects detailing discounts the shopper applied to their order at checkout.
        /// </summary>
        [JsonProperty("discountLines")]
        public List<DiscountLine> DiscountLines { get; set; }

        /// <summary>
        /// An array of objects detailing questions and answers the shopper provided at checkout, if they were presented with a form.
        /// </summary>
        [JsonProperty("formSubmission")]
        public List<FormSubmission> FormSubmission { get; set; }

        /// <summary>
        /// An array of fulfillment objects detailing shipment information for all shipments associated with the order.
        /// </summary>
        [JsonProperty("fulfillments")]
        public List<Fulfillment> Fulfillments { get; set; }

        /// <summary>
        /// Sub total
        /// </summary>
        [JsonProperty("subtotal")]
        public CurrencyValue Subtotal { get; set; }

        /// <summary>
        ///  Shipping total
        /// </summary>
        [JsonProperty("shippingTotal")]
        public CurrencyValue ShippingTotal { get; set; }

        /// <summary>
        /// Discount total
        /// </summary>
        [JsonProperty("discountTotal")]
        public CurrencyValue DiscountTotal { get; set; }

        /// <summary>
        /// Total tax
        /// </summary>
        [JsonProperty("taxTotal")]
        public CurrencyValue TaxTotal { get; set; }

        /// <summary>
        /// Total Refund
        /// </summary>
        [JsonProperty("refundedTotal")]
        public CurrencyValue RefundedTotal { get; set; }

        /// <summary>
        /// Grand Total
        /// </summary>
        [JsonProperty("grandTotal")]
        public CurrencyValue GrandTotal { get; set; }
    }
}