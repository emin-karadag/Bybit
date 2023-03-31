using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum TickDirectionEnum
    {
        /// <summary>
        /// price rise
        /// </summary>
        [Display(Name = "PlusTick")]
        PLUS_TICK,

        /// <summary>
        /// trade occurs at the same price as the previous trade, which occurred at a price higher than that for the trade preceding it
        /// </summary>
        [Display(Name = "ZeroPlusTick")]
        ZERO_PLUS_TICK,

        /// <summary>
        /// price drop
        /// </summary>
        [Display(Name = "MinusTick")]
        MINUS_TICK,

        /// <summary>
        /// trade occurs at the same price as the previous trade, which occurred at a price lower than that for the trade preceding it
        /// </summary>
        [Display(Name = "ZeroMinusTick")]
        ZERO_MINUS_TICK
    }
}
