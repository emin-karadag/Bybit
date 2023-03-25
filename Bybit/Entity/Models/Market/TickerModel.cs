using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Common;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class TickerModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public TickerData? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }
    }

    public partial class TickerData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<TickerDataList>? TickerDataList { get; set; }
    }

    public partial class TickerDataList
    {
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("bid1Price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Bid1Price { get; set; }

        [JsonPropertyName("bid1Size")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Bid1Size { get; set; }

        [JsonPropertyName("ask1Price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Ask1Price { get; set; }

        [JsonPropertyName("ask1Size")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Ask1Size { get; set; }

        [JsonPropertyName("lastPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal LastPrice { get; set; }

        [JsonPropertyName("prevPrice24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal PrevPrice24H { get; set; }

        [JsonPropertyName("price24hPcnt")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Price24HPcnt { get; set; }

        [JsonPropertyName("highPrice24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal HighPrice24H { get; set; }

        [JsonPropertyName("lowPrice24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal LowPrice24H { get; set; }

        [JsonPropertyName("turnover24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Turnover24H { get; set; }

        [JsonPropertyName("volume24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Volume24H { get; set; }

        [JsonPropertyName("usdIndexPrice")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? UsdIndexPrice { get; set; }


        [JsonPropertyName("indexPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? IndexPrice { get; set; }


        [JsonPropertyName("markPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? MarkPrice { get; set; }


        [JsonPropertyName("prevPrice1h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? PrevPrice1H { get; set; }


        [JsonPropertyName("openInterest")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? OpenInterest { get; set; }


        [JsonPropertyName("openInterestValue")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? OpenInterestValue { get; set; }


        [JsonPropertyName("fundingRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? FundingRate { get; set; }


        [JsonPropertyName("nextFundingTime")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? NextFundingTime { get; set; }


        [JsonPropertyName("predictedDeliveryPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? PredictedDeliveryPrice { get; set; }


        [JsonPropertyName("basisRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? BasisRate { get; set; }


        [JsonPropertyName("deliveryFeeRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? DeliveryFeeRate { get; set; }


        [JsonPropertyName("deliveryTime")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? DeliveryTime { get; set; }
        [JsonConverter(typeof(StringToDecimalConvertor))]

        [JsonPropertyName("basis")]
        public decimal? Basis { get; set; }


        [JsonPropertyName("bid1Iv")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Bid1Iv { get; set; }


        [JsonPropertyName("ask1Iv")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Ask1Iv { get; set; }


        [JsonPropertyName("markIv")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? MarkIv { get; set; }

        [JsonPropertyName("underlyingPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? UnderlyingPrice { get; set; }


        [JsonPropertyName("delta")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Delta { get; set; }


        [JsonPropertyName("gamma")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Gamma { get; set; }


        [JsonPropertyName("vega")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Vega { get; set; }


        [JsonPropertyName("theta")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Theta { get; set; }


        [JsonPropertyName("change24h")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? Change24H { get; set; }
    }
}
