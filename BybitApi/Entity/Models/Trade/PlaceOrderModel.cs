using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class PlaceOrderModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public PlaceOrderData? Result { get; set; }
    }

    public partial class PlaceOrderData
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = "";

        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = "";
    }
}
