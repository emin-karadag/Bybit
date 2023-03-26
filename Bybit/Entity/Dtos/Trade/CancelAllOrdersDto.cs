using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class CancelAllOrdersDto : IBybitDto
    {
        /// <summary>
        /// - Unified account: spot, linear, inverse, option
        /// - Normal account: spot, linear, inverse
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name. linear & inverse: Required if not passing baseCoin or settleCoin
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// - linear & inverse: If cancel all by baseCoin, it will cancel all linear & inverse orders. Required if not passing symbol or settleCoin
        /// - Normal spot: invalid
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// - linear & inverse: Required if not passing symbol or baseCoin
        /// - Does not support spot
        /// </summary>
        public string SettleCoin { get; set; } = "";

        /// <summary>
        /// Valid for spot only. Order, tpslOrder. If not passed, Order by default
        /// </summary>
        public string OrderFilter { get; set; } = "";
    }
}
