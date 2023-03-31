using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class InstrumentsInfoDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot,linear,inverse,option
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Base coin. linear,inverse,option only
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// Limit for data size per page. [1, 1000]. Default: 500
        /// </summary>
        public int Limit { get; set; } = 500;

        /// <summary>
        /// Cursor. Used for pagination
        /// </summary>
        public bool Cursor { get; set; }
    }
}
