using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum TypeEnum
    {
        [Display(Name = "TRANSFER_IN")]
        TRANSFER_IN,

        [Display(Name = "TRANSFER_OUT")]
        TRANSFER_OUT,

        [Display(Name = "TRADE")]
        TRADE,

        [Display(Name = "SETTLEMENT")]
        SETTLEMENT,

        [Display(Name = "DELIVERY")]
        DELIVERY,

        [Display(Name = "LIQUIDATION")]
        LIQUIDATION,

        [Display(Name = "BONUS")]
        BONUS,

        [Display(Name = "FEE_REFUND")]
        FEE_REFUND,

        [Display(Name = "INTEREST")]
        INTEREST,

        [Display(Name = "CURRENCY_BUY")]
        CURRENCY_BUY,

        [Display(Name = "CURRENCY_SELL")]
        CURRENCY_SELL,
    }
}
