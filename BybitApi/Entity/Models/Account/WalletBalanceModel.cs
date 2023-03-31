using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Account
{
    public class WalletBalanceModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public WalletBalanceData? Result { get; set; }
    }

    public partial class WalletBalanceData
    {
        [JsonPropertyName("list")]
        public List<WalletBalanceDataList>? WalletBalanceDataList { get; set; }
    }

    public partial class WalletBalanceDataList
    {
        [JsonPropertyName("totalEquity")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalEquity { get; set; }

        [JsonPropertyName("accountIMRate")]
        public string AccountImRate { get; set; } = "";

        [JsonPropertyName("totalMarginBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalMarginBalance { get; set; }

        [JsonPropertyName("totalInitialMargin")]
        public string TotalInitialMargin { get; set; } = "";

        [JsonPropertyName("accountType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypeEnum AccountType { get; set; }

        [JsonPropertyName("totalAvailableBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalAvailableBalance { get; set; }

        [JsonPropertyName("accountMMRate")]
        public string AccountMmRate { get; set; } = "";

        [JsonPropertyName("totalPerpUPL")]
        public string TotalPerpUpl { get; set; } = "";

        [JsonPropertyName("totalWalletBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalWalletBalance { get; set; }

        [JsonPropertyName("accountLTV")]
        public string AccountLtv { get; set; } = "";

        [JsonPropertyName("totalMaintenanceMargin")]
        public string TotalMaintenanceMargin { get; set; } = "";

        [JsonPropertyName("coin")]
        public List<Coin>? Coin { get; set; }
    }

    public partial class Coin
    {
        [JsonPropertyName("availableToBorrow")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long AvailableToBorrow { get; set; }

        [JsonPropertyName("bonus")]
        public string Bonus { get; set; } = "";

        [JsonPropertyName("accruedInterest")]
        public string AccruedInterest { get; set; } = "";

        [JsonPropertyName("availableToWithdraw")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal AvailableToWithdraw { get; set; }

        [JsonPropertyName("totalOrderIM")]
        public string TotalOrderIm { get; set; } = "";

        [JsonPropertyName("equity")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Equity { get; set; }

        [JsonPropertyName("totalPositionMM")]
        public string TotalPositionMm { get; set; } = "";

        [JsonPropertyName("usdValue")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal UsdValue { get; set; }

        [JsonPropertyName("unrealisedPnl")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal UnrealisedPnl { get; set; }

        [JsonPropertyName("borrowAmount")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal BorrowAmount { get; set; }

        [JsonPropertyName("totalPositionIM")]
        public string TotalPositionIm { get; set; } = "";

        [JsonPropertyName("walletBalance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal WalletBalance { get; set; }

        [JsonPropertyName("cumRealisedPnl")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal CumRealisedPnl { get; set; }

        [JsonPropertyName("coin")]
        public string CoinCoin { get; set; } = "";
    }
}
