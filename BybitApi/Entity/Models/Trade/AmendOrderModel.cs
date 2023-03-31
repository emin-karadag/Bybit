using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class AmendOrderModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public AmendOrderData? Result { get; set; }
    }

    public partial class AmendOrderData
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = "";

        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = "";
    }
}
