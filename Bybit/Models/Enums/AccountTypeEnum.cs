using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum AccountTypeEnum
    {
        /// <summary>
        /// UMA or UTA
        /// </summary>
        [Display(Name = "UNIFIED")]
        UNIFIED,

        /// <summary>
        /// Derivatives Account
        /// </summary>
        [Display(Name = "CONTRACT")]
        CONTRACT,

        /// <summary>
        /// Spot Account
        /// </summary>
        [Display(Name = "SPOT")]
        SPOT,

        /// <summary>
        /// ByFi Account
        /// </summary>
        [Display(Name = "INVESTMENT")]
        INVESTMENT,

        /// <summary>
        /// USDC Account
        /// </summary>
        [Display(Name = "OPTION")]
        OPTION,

        /// <summary>
        /// Funding Account
        /// </summary>
        [Display(Name = "FUND")]
        FUND
    }
}
