using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum TimeInForceEnum
    {
        /// <summary>
        /// GoodTillCancel
        /// </summary>

        [Display(Name = "GTC")]
        GTC,

        /// <summary>
        /// ImmediateOrCancel
        /// </summary>
        [Display(Name = "IOC")]
        IOC,

        /// <summary>
        /// FillOrKill
        /// </summary>
        [Display(Name = "FOK")]
        FOK,

        /// <summary>
        /// https://www.bybit.com/en-US/help-center/s/article/What-Is-A-Post-Only-Order
        /// </summary>
        [Display(Name = "PostOnly")]
        POSTONLY
    }
}
