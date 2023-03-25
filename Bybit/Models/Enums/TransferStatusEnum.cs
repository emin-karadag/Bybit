using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum TransferStatusEnum
    {
        [Display(Name = "SUCCESS")]
        SUCCESS,

        [Display(Name = "PENDING")]
        PENDING,

        [Display(Name = "FAILED")]
        FAILED
    }
}
