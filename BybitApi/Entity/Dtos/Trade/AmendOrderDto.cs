using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class AmendOrderDto : IBybitDto
    {
        /// <summary>
        /// Product type
        /// - Unified account: linear, inverse, option
        /// - Normal account: linear, inverse. Please note that category is not involved with business logic
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Order ID. Either orderId or orderLinkId is required
        /// </summary>
        public string OrderId { get; set; } = "";

        /// <summary>
        /// User customised order ID. Either orderId or orderLinkId is required
        /// </summary>
        public string OrderLinkId { get; set; } = "";

        /// <summary>
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed
        /// </summary>
        public string OrderIv { get; set; } = "";

        /// <summary>
        /// If you expect the price to rise to trigger your conditional order, make sure:
        /// - triggerPrice > market price Else, triggerPrice < market price
        /// </summary>
        public string TriggerPrice { get; set; } = "";

        /// <summary>
        /// Order quantity after modification. Do not pass it if not modify the qty
        /// </summary>
        public string Quantity { get; set; } = "";

        /// <summary>
        /// Order price after modification. Do not pass it if not modify the price
        /// </summary>
        public string Price { get; set; } = "";

        /// <summary>
        /// Take profit price after modification. Do not pass it if you do not want to modify the take profit
        /// </summary>
        public string TakeProfit { get; set; } = "";

        /// <summary>
        /// Stop loss price after modification. Do not pass it if you do not want to modify the stop loss
        /// </summary>
        public string StopLoss { get; set; } = "";

        /// <summary>
        /// The price type to trigger take profit. When set a take profit, this param is required if no initial value for the order
        /// </summary>
        public TriggerByEnum TpTriggerBy { get; set; }

        /// <summary>
        /// The price type to trigger stop loss. When set a take profit, this param is required if no initial value for the order
        /// </summary>
        public TriggerByEnum SlTriggerBy { get; set; }

        /// <summary>
        /// Trigger price type
        /// </summary>
        public TriggerByEnum TriggerBy { get; set; }
    }
}
