using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class CancelAllOrdersModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public CancelAllOrdersData? Result { get; set; }
    }

    public partial class CancelAllOrdersData
    {
        [JsonPropertyName("success")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int? Success { get; set; }

        [JsonPropertyName("list")]
        public List<CancelAllOrdersDataList>? CancelAllOrdersDataList { get; set; }
    }

    public partial class CancelAllOrdersDataList
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = "";

        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = "";
    }
}
