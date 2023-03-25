using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class RiskLimitDto : IBybitDto
    {
        /// <summary>
        /// Product type. linear,inverse
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; } = "";
    }
}
