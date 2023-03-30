using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Asset
{
    public class SingleCoinBalanceModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public SingleCoinBalanceData? Result { get; set; }
    }

    public partial class SingleCoinBalanceData
    {
        [JsonPropertyName("memberId")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long MemberId { get; set; }

        [JsonPropertyName("bizType")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int BizType { get; set; }

        [JsonPropertyName("accountType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypeEnum AccountType { get; set; }

        [JsonPropertyName("balance")]
        public Balance? Balance { get; set; }
    }
}
