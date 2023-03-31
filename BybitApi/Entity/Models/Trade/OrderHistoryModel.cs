using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Trade
{
    public class OrderHistoryModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public OrderHistoryData? Result { get; set; }
    }

    public partial class OrderHistoryData
    {
        [JsonPropertyName("nextPageCursor")]
        public string NextPageCursor { get; set; } = "";

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<OrderHistoryDataList>? OrderHistoryDataListList { get; set; }
    }

    public partial class OrderHistoryDataList
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("orderType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderTypeEnum OrderType { get; set; }

        [JsonPropertyName("orderLinkId")]
        public string OrderLinkId { get; set; } = "";

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = "";

        [JsonPropertyName("cancelType")]
        public string CancelType { get; set; } = "";

        [JsonPropertyName("avgPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal AvgPrice { get; set; }

        [JsonPropertyName("stopOrderType")]
        public string StopOrderType { get; set; } = "";

        [JsonPropertyName("lastPriceOnCreated")]
        public string LastPriceOnCreated { get; set; } = "";

        [JsonPropertyName("orderStatus")]
        public string OrderStatus { get; set; } = "";

        [JsonPropertyName("takeProfit")]
        public string TakeProfit { get; set; } = "";

        [JsonPropertyName("cumExecValue")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal CumExecValue { get; set; }

        [JsonPropertyName("triggerDirection")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int TriggerDirection { get; set; }

        [JsonPropertyName("blockTradeId")]
        public string BlockTradeId { get; set; } = "";

        [JsonPropertyName("rejectReason")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RejectReasonEnum RejectReason { get; set; }

        [JsonPropertyName("isLeverage")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int IsLeverage { get; set; }

        [JsonPropertyName("price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Price { get; set; }

        [JsonPropertyName("orderIv")]
        public string OrderIv { get; set; } = "";

        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime CreatedTime { get; set; }

        [JsonPropertyName("tpTriggerBy")]
        public string TpTriggerBy { get; set; } = "";

        [JsonPropertyName("positionIdx")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int PositionIdx { get; set; }

        [JsonPropertyName("timeInForce")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TimeInForceEnum TimeInForce { get; set; }

        [JsonPropertyName("leavesValue")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int LeavesValue { get; set; }

        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("side")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderSideEnum Side { get; set; }

        [JsonPropertyName("triggerPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TriggerPrice { get; set; }

        [JsonPropertyName("cumExecFee")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal CumExecFee { get; set; }

        [JsonPropertyName("slTriggerBy")]
        public string SlTriggerBy { get; set; } = "";

        [JsonPropertyName("leavesQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal LeavesQty { get; set; }

        [JsonPropertyName("closeOnTrigger")]
        public bool CloseOnTrigger { get; set; }

        [JsonPropertyName("cumExecQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal CumExecQty { get; set; }

        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }

        [JsonPropertyName("qty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Qty { get; set; }

        [JsonPropertyName("stopLoss")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal StopLoss { get; set; }

        [JsonPropertyName("triggerBy")]
        public string TriggerBy { get; set; } = "";
    }
}
