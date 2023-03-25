using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum IntervalEnum
    {
        [Display(Name = "1")]
        MINUTE_1,

        [Display(Name = "3")]
        MINUTE_3,

        [Display(Name = "5")]
        MINUTE_5,

        [Display(Name = "15")]
        MINUTE_15,

        [Display(Name = "30")]
        MINUTE_30,

        [Display(Name = "60")]
        MINUTE_60,

        [Display(Name = "120")]
        MINUTE_120,

        [Display(Name = "240")]
        MINUTE_240,

        [Display(Name = "360")]
        MINUTE_360,

        [Display(Name = "720")]
        MINUTE_720,

        [Display(Name = "D")]
        DAY,

        [Display(Name = "W")]
        WEEK,

        [Display(Name = "M")]
        MONTH
    }
}
