using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class PublicTradingHistoryModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public PublicTradingHistoryData? Result { get; set; }
    }

    public partial class PublicTradingHistoryData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<PublicTradingHistoryDataList>? PublicTradingHistoryDataList { get; set; }
    }

    public partial class PublicTradingHistoryDataList
    {
        [JsonPropertyName("execId")]
        public string ExecId { get; set; } = "";

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Price { get; set; }

        [JsonPropertyName("size")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Size { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; } = "";

        [JsonPropertyName("time")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime Time { get; set; }

        [JsonPropertyName("isBlockTrade")]
        public bool IsBlockTrade { get; set; }
    }
}
