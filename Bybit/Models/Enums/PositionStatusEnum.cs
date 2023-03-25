using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum PositionStatusEnum
    {
        [Display(Name = "Normal")]
        Normal,

        /// <summary>
        /// in the liquidation progress
        /// </summary>
        [Display(Name = "Liq")]
        Liq,

        /// <summary>
        /// in the auto-deleverage progress
        /// </summary>
        [Display(Name = "Adl")]
        Adl
    }
}
