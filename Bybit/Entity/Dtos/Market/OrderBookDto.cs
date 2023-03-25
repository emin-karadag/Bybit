using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Market
{
    public class OrderBookDto : IBybitDto
    {
        /// <summary>
        /// Product type. spot, linear, inverse, option
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }


        private int _limit;

        /// <summary>
        /// Limit size for each bid and ask
        /// spot: [1, 50]. Default: 1.
        /// linear&inverse: [1, 200]. Default: 25.
        /// option: [1, 25]. Default: 1.
        /// </summary>
        public int Limit
        {
            get
            {
                if (_limit == 0)
                    _limit = Category switch
                    {
                        CategoryEnum.SPOT or CategoryEnum.OPTION => 1,
                        _ => 25,
                    };
                return _limit;
            }
            set { _limit = value; }
        }
    }
}
