using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "PreLaunch")]
        PRE_LAUNCH,

        [Display(Name = "Trading")]
        TRADING,

        [Display(Name = "Settling")]
        SETTLING,

        [Display(Name = "Delivering")]
        DELIVERING,

        [Display(Name = "Closed")]
        CLOSED
    }
}
