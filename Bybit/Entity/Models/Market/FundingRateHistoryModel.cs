using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Common;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class FundingRateHistoryModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public FundingRateHistoryData? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }
    }

    public partial class FundingRateHistoryData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }


        [JsonPropertyName("list")]
        public List<FundingRateHistoryDataList>? FundingRateHistoryDataList { get; set; }
    }

    public partial class FundingRateHistoryDataList
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";


        [JsonPropertyName("fundingRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal FundingRate { get; set; }


        [JsonPropertyName("fundingRateTimestamp")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime FundingRateTimestamp { get; set; }
    }
}
