using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class FundingRateHistoryDto : IBybitDto
    {
        /// <summary>
        /// Product type. linear,inverse
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; } = "";

        /// <summary>
        /// The start timestamp
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end timestamp
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Limit for data size per page. [1, 200]. Default: 200
        /// </summary>
        public int Limit { get; set; } = 200;
    }
}
