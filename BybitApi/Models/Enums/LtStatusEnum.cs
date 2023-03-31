using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum LtStatusEnum
    {
        /// <summary>
        /// LT can be purchased and redeemed
        /// </summary>
        [Display(Name = "1")]
        PURCHASED_AND_REDEEMED,

        /// <summary>
        /// LT can be purchased, but not redeemed
        /// </summary>
        [Display(Name = "2")]
        PURCHASED_NOT_REDEEMED,

        /// <summary>
        /// LT can be redeemed, but not purchased
        /// </summary>
        [Display(Name = "3")]
        REDEEMED_NOT_PURCHASED,

        /// <summary>
        /// LT cannot be purchased nor redeemed
        /// </summary>
        [Display(Name = "4")]
        PURCHASED_NOR_REDEEMED,

        /// <summary>
        /// Adjusting position
        /// </summary>
        [Display(Name = "5")]
        ADJUSTING_POSITION
    }
}
