using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum CancelTypeEnum
    {
        [Display(Name = "CancelByUser")]
        CANCEL_BY_USER,

        [Display(Name = "CancelByReduceOnly")]
        CANCEL_BY_REDUCE_ONLY,

        /// <summary>
        /// Cancelled due to liquidation
        /// </summary>
        [Display(Name = "CancelByPrepareLiq")]
        CANCEL_BY_PREPEARE_LIQ,

        /// <summary>
        /// Cancelled due to liquidation
        /// </summary>
        [Display(Name = "CancelAllBeforeLiq")]
        CANCEL_ALL_BEFORE_LIQ,

        /// <summary>
        /// Cancelled due to ADL
        /// </summary>
        [Display(Name = "CancelByPrepareAdl")]
        CANCEL_BY_PREPEARE_ADL,

        /// <summary>
        /// Cancelled due to ADL
        /// </summary>
        [Display(Name = "CancelAllBeforeAdl")]
        CANCEL_ALL_BEFORE_ADL,

        [Display(Name = "CancelByAdmin")]
        CANCEL_BY_ADMIN,

        [Display(Name = "CancelByTpSlTsClear")]
        CANCEL_BY_TP_SL_TS_CLEAR,

        [Display(Name = "CancelByPzSideCh")]
        CANCEL_BY_PZ_SIDE_CH,

        [Display(Name = "CancelBySettle")]
        CANCEL_BY_SETTLE,

        [Display(Name = "CancelByCannotAffordOrderCost")]
        CANCEL_BY_CANNOT_AFFORD_ORDER_COST,

        [Display(Name = "CancelByPmTrialMmOverEquity")]
        CANCEL_BY_PM_TRIAL_MM_OVER_EQUITY,

        [Display(Name = "CancelByAccountBlocking")]
        CANCEL_BY_ACCOUNT_BLOCKING,

        [Display(Name = "CancelByDelivery")]
        CANCEL_BY_DELIVERY,

        [Display(Name = "CancelByMmpTriggered")]
        CANCEL_BY_MMP_TRIGGERED,

        [Display(Name = "CancelByCrossSelfMuch")]
        CANCEL_BY_CORSS_SELF_MUCH,

        [Display(Name = "CancelByCrossReachMaxTradeNum")]
        CANCEL_BY_CROSS_REACH_MAX_TRADE_NUM,

        [Display(Name = "CancelByDCP")]
        CANCEL_BY_DCP
    }
}
