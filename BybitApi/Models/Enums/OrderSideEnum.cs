using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum OrderSideEnum
    {
        [Display(Name = "Buy")]
        BUY,

        [Display(Name = "Sell")]
        SELL
    }
}
