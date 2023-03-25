using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum PeriodEnum
    {
        [Display(Name = "7")]
        DAY_7,

        [Display(Name = "14")]
        DAY_14,

        [Display(Name = "21")]
        DAY_21,

        [Display(Name = "30")]
        DAY_30,

        [Display(Name = "60")]
        DAY_60,

        [Display(Name = "90")]
        DAY_90,

        [Display(Name = "180")]
        DAY_180,

        [Display(Name = "270")]
        DAY_270
    }
}
