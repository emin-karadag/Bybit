using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Account
{
    public class FeeRateModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public FeeRateData? Result { get; set; }
    }

    public partial class FeeRateData
    {
        [JsonPropertyName("list")]
        public List<FeeRateDataList>? FeeRateDataList { get; set; }
    }

    public partial class FeeRateDataList
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("takerFeeRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TakerFeeRate { get; set; }

        [JsonPropertyName("makerFeeRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MakerFeeRate { get; set; }
    }
}
