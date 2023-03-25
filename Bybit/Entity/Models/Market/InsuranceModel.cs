using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Common;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class InsuranceModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public InsuranceData? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }
    }

    public partial class InsuranceData
    {
        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("list")]
        public List<InsuranceDataList>? InsuranceDataList { get; set; }
    }

    public partial class InsuranceDataList
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; } = "";

        [JsonPropertyName("balance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Balance { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Value { get; set; }
    }
}
