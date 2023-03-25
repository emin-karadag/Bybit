using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class DeliveryPriceDto : IBybitDto
    {
        /// <summary>
        /// Product type. linear, inverse, option
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base coin. Default: BTC. valid for option only
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// Limit for data size per page. [1, 200]. Default: 50
        /// </summary>
        public int Limit { get; set; } = 50;

        /// <summary>
        /// Cursor. Used for pagination
        /// </summary>
        public string Cursor { get; set; } = "";
    }
}
