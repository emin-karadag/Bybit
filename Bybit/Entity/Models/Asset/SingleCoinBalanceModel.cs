using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Entity.Dtos.Asset;
using Bybit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
