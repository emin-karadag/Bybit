using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class RiskLimitModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public RiskLimitData? Result { get; set; }
    }

    public partial class RiskLimitData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<RiskLimitDataList>? RiskLimitDataList { get; set; }
    }

    public partial class RiskLimitDataList
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("riskLimitValue")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long RiskLimitValue { get; set; }

        [JsonPropertyName("maintenanceMargin")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaintenanceMargin { get; set; }

        [JsonPropertyName("initialMargin")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal InitialMargin { get; set; }

        [JsonPropertyName("isLowestRisk")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int IsLowestRisk { get; set; }

        [JsonPropertyName("maxLeverage")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaxLeverage { get; set; }
    }
}
