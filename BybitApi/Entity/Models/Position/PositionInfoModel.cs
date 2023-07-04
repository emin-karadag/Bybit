using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace BybitApi.Entity.Models.Position
{
    public class PositionInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public PositionInfoData? Result { get; set; }
    }

    public partial class PositionInfoData
    {
        [JsonPropertyName("nextPageCursor")]
        public string NextPageCursor { get; set; } = "";

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<PositionInfoDataList> Positions { get; set; } = new();
    }

    public partial class PositionInfoDataList
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("leverage")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Leverage { get; set; }

        [JsonPropertyName("autoAddMargin")]
        public long AutoAddMargin { get; set; }

        [JsonPropertyName("avgPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal AvgPrice { get; set; }

        [JsonPropertyName("liqPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal LiqPrice { get; set; }

        [JsonPropertyName("riskLimitValue")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long RiskLimitValue { get; set; }

        [JsonPropertyName("takeProfit")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? TakeProfit { get; set; }

        [JsonPropertyName("positionValue")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal PositionValue { get; set; }

        [JsonPropertyName("tpslMode")]
        public string TpslMode { get; set; } = "";

        [JsonPropertyName("riskId")]
        public int RiskId { get; set; }

        [JsonPropertyName("trailingStop")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TrailingStop { get; set; }

        [JsonPropertyName("unrealisedPnl")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal UnrealisedPnl { get; set; }

        [JsonPropertyName("markPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("adlRankIndicator")]
        public int AdlRankIndicator { get; set; }

        [JsonPropertyName("cumRealisedPnl")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal CumRealisedPnl { get; set; }

        [JsonPropertyName("positionMM")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal PositionMm { get; set; }

        [JsonPropertyName("createdTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime CreatedTime { get; set; }

        [JsonPropertyName("positionIdx")]
        public int PositionIdx { get; set; }

        [JsonPropertyName("positionIM")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal PositionIm { get; set; }

        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("side")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderSideEnum Side { get; set; }

        [JsonPropertyName("bustPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? BustPrice { get; set; }

        [JsonPropertyName("positionBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal PositionBalance { get; set; }

        [JsonPropertyName("size")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Size { get; set; }

        [JsonPropertyName("positionStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PositionStatusEnum PositionStatus { get; set; }

        [JsonPropertyName("stopLoss")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? StopLoss { get; set; }

        [JsonPropertyName("tradeMode")]
        public int TradeMode { get; set; }
    }
}
