﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SquareSpaceSharp.Entities
{
    public class StockOperation
    {
        [JsonProperty("variantId")] public string VariantId { get; set; }

        [JsonProperty("quantity")] public int Quantity { get; set; }
    }

    public class StockAdjustmentQuery
    {
        /// <summary>
        /// optional: An array of objects specifying a variant id and the amount to add to that variant's stock quantity, quantity values must be greater than or equal to 1.
        /// </summary>
        [JsonProperty("incrementOperations")]
        public List<StockOperation> IncrementOperations { get; set; }

        /// <summary>
        /// optional: An array of objects specifying a variant id and the amount to subtract from that variant's stock quantity, quantity values must be greater than or equal to 1.
        /// </summary>
        [JsonProperty("decrementOperations")]
        public List<StockOperation> DecrementOperations { get; set; }

        /// <summary>
        /// optional: An array of objects specifying a variant id and the exact quantity in stock for that variant, quantity values must be greater than or equal to 0.
        /// </summary>
        [JsonProperty("setFiniteOperations")]
        public List<StockOperation> SetFiniteOperations { get; set; }

        /// <summary>
        /// optional: An array of variants ids representing one or more variants that should be marked as having unlimited stock.
        /// </summary>
        [JsonProperty("setUnlimitedOperations")]
        public List<string> SetUnlimitedOperations { get; set; }
    }
}