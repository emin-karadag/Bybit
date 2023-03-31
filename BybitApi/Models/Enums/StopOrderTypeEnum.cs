using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum StopOrderTypeEnum
    {
        [Display(Name = "TakeProfit")]
        TAKE_PROFIT,

        [Display(Name = "StopLoss")]
        STOP_LOSS,

        [Display(Name = "TrailingStop")]
        TRAILING_STOP,

        [Display(Name = "Stop")]
        STOP,

        [Display(Name = "PartialTakeProfit")]
        PARTIAL_TAKE_PROFIT,

        [Display(Name = "PartialStopLoss")]
        PARTIAL_STOP_LOSS,

        /// <summary>
        /// spot TP/SL order
        /// </summary>
        [Display(Name = "tpslOrder")]
        TP_SL_ORDER
    }
}
