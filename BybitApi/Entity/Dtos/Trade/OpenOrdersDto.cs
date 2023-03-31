using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class OpenOrdersDto : IBybitDto
    {
        /// <summary>
        /// - Unified account: spot, linear, inverse, option
        /// - Normal account: spot, linear, inverse
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name. For linear & inverse, either symbol or settleCoin is required
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base coin. For option only. Return all option open orders if not passed
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// - linear & inverse: either symbol or settleCoin is required
        /// - spot: invalid
        /// </summary>
        public string SettleCoin { get; set; } = "";

        /// <summary>
        /// Order ID
        /// </summary>
        public string OrderId { get; set; } = "";

        /// <summary>
        /// User customised order ID
        /// </summary>
        public string OrderLinkId { get; set; } = "";

        /// <summary>
        /// - 0: Unified account & Normal account
        /// - 1: Unified account - spot / linear / option
        /// - 2: Unified account - inverse & Normal account - linear / inverse
        /// </summary>
        public short OpenOnly { get; set; }

        /// <summary>
        /// Order: active order, StopOrder: conditional order, tpslOrder: spot TP/SL order
        /// - Normal spot: return Order active order by default
        /// - Others: all kinds of orders by default
        /// </summary>
        public string OrderFilter { get; set; } = "";

        /// <summary>
        /// Limit for data size per page. [1, 50]. Default: 20
        /// </summary>
        public int Limit { get; set; } = 20;

        /// <summary>
        /// Cursor. Used for pagination
        /// </summary>
        public string Cursor { get; set; } = "";
    }
}
