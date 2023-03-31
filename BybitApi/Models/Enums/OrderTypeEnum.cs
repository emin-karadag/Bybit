using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum OrderTypeEnum
    {
        [Display(Name = "Limit")]
        LIMIT,

        [Display(Name = "Market")]
        MARKET
    }
}
