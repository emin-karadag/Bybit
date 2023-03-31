using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum ContractTypeEnum
    {
        [Display(Name = "InversePerpetual")]
        INVERSEPERPETUAL,

        [Display(Name = "LinearPerpetual")]
        LINEARPERPETUAL,

        [Display(Name = "InverseFutures")]
        INVERSEFUTURES
    }
}
