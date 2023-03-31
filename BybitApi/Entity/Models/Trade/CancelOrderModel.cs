using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class CancelOrderModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public CancelOrderData? Result { get; set; }
    }

    public partial class CancelOrderData
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = "";

        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = "";
    }
}
