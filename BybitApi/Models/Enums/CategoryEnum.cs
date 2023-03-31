using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum CategoryEnum
    {
        [Display(Name = "spot")]
        SPOT,

        /// <summary>
        /// Unified Account -> USDT and USDC perpetual
        /// Normal Account  -> USDT perp
        /// </summary>
        [Display(Name = "linear")]
        LINEAR,

        /// <summary>
        /// Inverse contract, including Inverse perp, Inverse futures
        /// </summary>
        [Display(Name = "inverse")]
        INVERSE,

        [Display(Name = "option")]
        OPTION
    }
}
