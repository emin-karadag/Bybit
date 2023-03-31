using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum TriggerByEnum
    {
        [Display(Name = "LastPrice")]
        LAST_PRICE,

        [Display(Name = "IndexPrice")]
        INDEX_PRICE,

        [Display(Name = "MarkPrice")]
        MARK_PRICE
    }
}
