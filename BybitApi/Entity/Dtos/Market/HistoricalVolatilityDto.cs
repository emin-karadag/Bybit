using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class HistoricalVolatilityDto : IBybitDto
    {
        /// <summary>
        /// Base coin. Default: return BTC data
        /// </summary>
        public string BaseCoin { get; set; } = "BTC";

        /// <summary>
        /// Period
        /// </summary>
        public PeriodEnum? Period { get; set; }

        /// <summary>
        /// The start timestamp
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The end timestamp 
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
