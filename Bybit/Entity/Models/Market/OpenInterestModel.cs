using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Common;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class OpenInterestModel : BybitBaseModel, IBybitModel
    {

        [JsonPropertyName("result")]
        public OpenInterestData? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }
    }

    public partial class OpenInterestData
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<OpenInterestDataList>? OpenInterestDataList { get; set; }

        [JsonPropertyName("nextPageCursor")]
        public string NextPageCursor { get; set; } = "";
    }

    public partial class OpenInterestDataList
    {
        [JsonPropertyName("openInterest")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal OpenInterest { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime Timestamp { get; set; }
    }

}
