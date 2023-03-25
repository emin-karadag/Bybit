using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum PositionIdxEnum
    {
        /// <summary>
        /// one-way mode position
        /// </summary>
        [Display(Name = "0")]
        ONE_WAY_MODE,

        /// <summary>
        /// Buy side of hedge-mode position
        /// </summary>
        [Display(Name = "1")]
        BUY_SIDE_HEDGE_MODE,

        /// <summary>
        /// Sell side of hedge-mode position
        /// </summary>
        [Display(Name = "2")]
        SELL_SIDE_HEDGE_MODE
    }
}
