using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum WithdrawStatusEnum
    {
        [Display(Name = "SecurityCheck")]
        SECURITY_CHECK,

        [Display(Name = "Pending")]
        PENDING,

        [Display(Name = "success")]
        SUCCESS,

        [Display(Name = "CancelByUser")]
        CANCEL_BY_USER,

        [Display(Name = "Reject")]
        REJECT,

        [Display(Name = "Fail")]
        FAIL,

        [Display(Name = "BlockchainConfirmed")]
        BLOCKCHAIN_CONFIRMED
    }
}
