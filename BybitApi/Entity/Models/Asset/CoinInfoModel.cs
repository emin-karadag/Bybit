using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Asset
{
    public class CoinInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public CoinInfoData? Result { get; set; }
    }

    public partial class CoinInfoData
    {
        [JsonPropertyName("rows")]
        public List<CoinInfoDataRow>? Rows { get; set; }
    }

    public partial class CoinInfoDataRow
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("coin")]
        public string Coin { get; set; } = "";

        [JsonPropertyName("remainAmount")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long RemainAmount { get; set; }

        [JsonPropertyName("chains")]
        public List<Chain>? Chains { get; set; }
    }

    public partial class Chain
    {
        [JsonPropertyName("chainType")]
        public string ChainType { get; set; } = "";

        [JsonPropertyName("confirmation")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Confirmation { get; set; }

        [JsonPropertyName("withdrawFee")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal WithdrawFee { get; set; }

        [JsonPropertyName("depositMin")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal DepositMin { get; set; }

        [JsonPropertyName("withdrawMin")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal WithdrawMin { get; set; }

        [JsonPropertyName("chain")]
        public string ChainChain { get; set; } = "";

        [JsonPropertyName("chainDeposit")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int ChainDeposit { get; set; }

        [JsonPropertyName("chainWithdraw")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int ChainWithdraw { get; set; }

        [JsonPropertyName("minAccuracy")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int MinAccuracy { get; set; }

        [JsonPropertyName("withdrawPercentageFee")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal WithdrawPercentageFee { get; set; }
    }
}
