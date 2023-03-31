using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum RejectReasonEnum
    {
        [Display(Name = "EC_NoError")]
        EC_NoError,

        [Display(Name = "EC_Others")]
        EC_Others,

        [Display(Name = "EC_UnknownMessageType")]
        EC_UnknownMessageType,

        [Display(Name = "EC_MissingClOrdID")]
        EC_MissingClOrdID,

        [Display(Name = "EC_MissingOrigClOrdID")]
        EC_MissingOrigClOrdID,

        [Display(Name = "EC_ClOrdIDOrigClOrdIDAreTheSame")]
        EC_ClOrdIDOrigClOrdIDAreTheSame,

        [Display(Name = "EC_DuplicatedClOrdID")]
        EC_DuplicatedClOrdID,

        [Display(Name = "EC_OrigClOrdIDDoesNotExist")]
        EC_OrigClOrdIDDoesNotExist,

        [Display(Name = "EC_TooLateToCancel")]
        EC_TooLateToCancel,

        [Display(Name = "EC_UnknownOrderType")]
        EC_UnknownOrderType,

        [Display(Name = "EC_UnknownSide")]
        EC_UnknownSide,

        [Display(Name = "EC_UnknownTimeInForce")]
        EC_UnknownTimeInForce,

        [Display(Name = "EC_WronglyRouted")]
        EC_WronglyRouted,

        [Display(Name = "EC_MarketOrderPriceIsNotZero")]
        EC_MarketOrderPriceIsNotZero,

        [Display(Name = "EC_LimitOrderInvalidPrice")]
        EC_LimitOrderInvalidPrice,

        [Display(Name = "EC_NoEnoughQtyToFill")]
        EC_NoEnoughQtyToFill,

        [Display(Name = "EC_NoImmediateQtyToFill")]
        EC_NoImmediateQtyToFill,

        [Display(Name = "EC_PerCancelRequest")]
        EC_PerCancelRequest,

        [Display(Name = "EC_MarketOrderCannotBePostOnly")]
        EC_MarketOrderCannotBePostOnly,

        [Display(Name = "EC_PostOnlyWillTakeLiquidity")]
        EC_PostOnlyWillTakeLiquidity,

        [Display(Name = "EC_CancelReplaceOrder")]
        EC_CancelReplaceOrder,

        [Display(Name = "EC_InvalidSymbolStatus")]
        EC_InvalidSymbolStatus
    }
}
