using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum SymbolEnum
    {
        [Display(Name = "BTCUSDT")]
        BTCUSDT,

        [Display(Name = "ETHUSDT")]
        ETHUSDT,

        [Display(Name = "BTCPERP")]
        BTCPERP,

        [Display(Name = "ETHPERP")]
        ETHPERP,

        [Display(Name = "BTCUSD")]
        BTCUSD,

        [Display(Name = "ETHUSD")]
        ETHUSD,

        /// <summary>
        /// H: First quarter; 23: 2023
        /// </summary>
        [Display(Name = "BTCUSDH23")]
        BTCUSDH23,

        /// <summary>
        /// M: Second quarter; 23: 2023
        /// </summary>
        [Display(Name = "BTCUSDM23")]
        BTCUSDM23,

        /// <summary>
        /// U: Third quarter; 23: 2023
        /// </summary>
        [Display(Name = "BTCUSDU23")]
        BTCUSDU23,

        /// <summary>
        /// Z: Fourth quarter; 23: 2023
        /// </summary>
        [Display(Name = "BTCUSDZ23")]
        BTCUSDZ23,

        [Display(Name = "ETHUSDC")]
        ETHUSDC
    }
}
