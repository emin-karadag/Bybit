using System.ComponentModel.DataAnnotations;

namespace Bybit.Models.Enums
{
    public enum OrderStatusEnum
    {
        /// <summary>
        /// order has been accepted by the system but not yet put through the matching engine
        /// </summary>
        [Display(Name = "Created")]
        CREATED,

        /// <summary>
        /// order has been placed successfully
        /// </summary>
        [Display(Name = "New")]
        NEW,

        [Display(Name = "Rejected")]
        REJECTED,

        [Display(Name = "PartiallyFilled")]
        PARTIALLY_FILLED,

        /// <summary>
        /// spot has this order status only
        /// </summary>
        [Display(Name = "PartiallyFilledCanceled")]
        PARTIALLY_FILLED_CANCELED,

        [Display(Name = "Filled")]
        FILLED,

        [Display(Name = "Cancelled")]
        CANCELED,

        [Display(Name = "Untriggered")]
        UNTRIGGERED,

        [Display(Name = "Triggered")]
        TRIGGERED,

        [Display(Name = "Deactivated")]
        DEACTIVATED,

        /// <summary>
        /// order has been triggered and the new active order has been successfully placed. Is the final state of a successful conditional order
        /// </summary>
        [Display(Name = "Active")]
        ACTIVE
    }
}
