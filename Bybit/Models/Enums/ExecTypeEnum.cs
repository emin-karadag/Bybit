using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum ExecTypeEnum
    {
        [Display(Name = "Trade")]
        TRADE,

        /// <summary>
        /// https://www.bybit.com/en-US/help-center/s/article/What-is-Auto-Deleveraging-ADL
        /// </summary>
        [Display(Name = "AdlTrade")]
        ADL_TRADE,

        /// <summary>
        /// https://www.bybit.com/en-US/help-center/bybitHC_Article?id=000001123&language=en_US
        /// </summary>
        [Display(Name = "Funding")]
        FUNDING,

        /// <summary>
        /// Liquidation
        /// </summary>
        [Display(Name = "BustTrade")]
        BUST_TRADE,

        [Display(Name = "Settle")]
        SETTLE
    }
}
