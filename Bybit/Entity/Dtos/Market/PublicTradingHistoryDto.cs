using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class PublicTradingHistoryDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot,linear,inverse,option
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Base coin. For option only. If not passed, return BTC data by default
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// Option type. Call or Put. For option only
        /// </summary>
        public string OptionType { get; set; } = "";

        private int _limit;

        /// <summary>
        /// Limit for data size per page.  
        /// spot: [1,60], default: 60. 
        /// others: [1,1000], default: 500
        /// </summary>
        public int Limit
        {
            get
            {
                if (_limit == 0)
                    _limit = Category switch
                    {
                        CategoryEnum.SPOT => 60,
                        _ => 500,
                    };
                return _limit;
            }
            set { _limit = value; }
        }
    }
}
