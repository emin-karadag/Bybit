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
    public class AllCoinsBalanceModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public AllCoinsBalanceData? Result { get; set; }
    }

    public partial class AllCoinsBalanceData
    {
        [JsonPropertyName("memberId")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long MemberId { get; set; }

        [JsonPropertyName("accountType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypeEnum AccountType { get; set; }

        [JsonPropertyName("balance")]
        public List<Balance>? Balances { get; set; }
    }

    public partial class Balance
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; } = "";

        [JsonPropertyName("transferBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TransferBalance { get; set; }

        [JsonPropertyName("walletBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal WalletBalance { get; set; }

        [JsonPropertyName("bonus")]
        public string Bonus { get; set; } = "";

        [JsonPropertyName("transferSafeAmount")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? TransferSafeAmount { get; set; }
    }
}
