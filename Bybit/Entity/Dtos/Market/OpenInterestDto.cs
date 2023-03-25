using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class OpenInterestDto : IBybitDto
    {
        /// <summary>
        /// Product type. linear,inverse
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Interval. 5min,15min,30min,1h,4h,1d
        /// </summary>
        public required string IntervalTime { get; set; }

        /// <summary>
        /// The start timestamp
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end timestamp
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Limit for data size per page. [1, 200]. Default: 50
        /// </summary>
        public int Limit { get; set; } = 50;

        /// <summary>
        /// Cursor. Used to paginate
        /// </summary>
        public string Cursor { get; set; } = "";
    }
}
