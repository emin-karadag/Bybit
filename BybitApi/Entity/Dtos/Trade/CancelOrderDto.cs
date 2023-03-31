using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class CancelOrderDto : IBybitDto
    {
        /// <summary>
        /// Product type
        /// - Unified account: spot, linear, inverse, option
        /// - Normal account: spot, linear, inverse
        /// </summary>
        public CategoryEnum Category { get; set; }

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
        /// Valid for spot only. Order,tpslOrder. If not passed, Order by default
        /// </summary>
        public string OrderFilter { get; set; } = "";
    }
}
