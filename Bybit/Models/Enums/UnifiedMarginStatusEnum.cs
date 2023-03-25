using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum UnifiedMarginStatusEnum
    {
        /// <summary>
        /// Regular account
        /// </summary>
        [Display(Name = "1")]
        REGULAR_ACCOUNT,

        /// <summary>
        /// Unified margin account, it only trades linear perpetual and options.
        /// </summary>
        [Display(Name = "2")]
        UNIFIED_MARGIN_ACCOUNT,

        /// <summary>
        /// Unified trade account, it can trade linear perpetual, options and spot
        /// </summary>
        [Display(Name = "3")]
        UNIFIED_TRADE_ACCOUNT
    }
}
