using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class BorrowQuotaDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Transaction side. Buy,Sell
        /// </summary>
        public OrderSideEnum Side { get; set; }
    }
}
