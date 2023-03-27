using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Account
{
    public class FeeRateDto : IBybitDto
    {
        /// <summary>
        /// Product type. linear, inverse, option
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name. Valid for linear, inverse, spot
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base coin. SOL, BTC, ETH. Valid for option
        /// </summary>
        public string BaseCoin { get; set; } = "";
    }
}
