using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class KLineDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot,linear,inverse
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Kline interval. 1,3,5,15,30,60,120,240,360,720,D,M,W
        /// </summary>
        public required IntervalEnum Interval { get; set; }

        /// <summary>
        /// The start timestamp (ms)
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end timestamp (ms)
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Limit for data size per page. [1, 200]. Default: 200
        /// </summary>
        public int Limit { get; set; } = 200;
    }
}
