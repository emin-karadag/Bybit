using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class BorrowQuotaModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public BorrowQuotaData? Result { get; set; }
    }

    public partial class BorrowQuotaData
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("maxTradeQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaxTradeQty { get; set; }

        [JsonPropertyName("side")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderSideEnum Side { get; set; }

        [JsonPropertyName("maxTradeAmount")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaxTradeAmount { get; set; }

        [JsonPropertyName("borrowCoin")]
        public string BorrowCoin { get; set; } = "";
    }

}
