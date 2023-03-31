using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Account
{
    internal class AccountInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public AccountInfoData? Result { get; set; }
    }

    public partial class AccountInfoData
    {
        [JsonPropertyName("marginMode")]
        public string MarginMode { get; set; } = "";

        [JsonPropertyName("updatedTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("unifiedMarginStatus")]
        public UnifiedMarginStatusEnum UnifiedMarginStatus { get; set; }
    }
}
