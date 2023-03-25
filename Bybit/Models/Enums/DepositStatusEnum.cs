using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum DepositStatusEnum
    {
        [Display(Name = "0")]
        UNKNOWN,

        [Display(Name = "1")]
        TO_BE_CONFIRMED,

        [Display(Name = "2")]
        PROCESSING,

        [Display(Name = "3")]
        SUCCESS,

        [Display(Name = "4")]
        DEPOSIT_FAILED
    }
}
