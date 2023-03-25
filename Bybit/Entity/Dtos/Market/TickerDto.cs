using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class TickerDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot,linear,inverse,option
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base coin. For option only
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// Expiry date. e.g., 25DEC22. For option only
        /// </summary>
        public string ExpDate { get; set; } = "";
    }
}
