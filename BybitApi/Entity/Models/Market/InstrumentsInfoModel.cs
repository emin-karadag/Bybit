using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class InstrumentsInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public InstrumentsInfoData? Result { get; set; }
    }

    public partial class InstrumentsInfoData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }


        [JsonPropertyName("list")]
        public List<InstrumentsInfoDataList>? InstrumentsInfoDataList { get; set; }

        [JsonPropertyName("nextPageCursor")]
        public string? NextPageCursor { get; set; }
    }

    public partial class InstrumentsInfoDataList
    {
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }


        [JsonPropertyName("baseCoin")]
        public string? BaseCoin { get; set; }


        [JsonPropertyName("quoteCoin")]
        public string? QuoteCoin { get; set; }


        [JsonPropertyName("innovation")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int? Innovation { get; set; }


        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StatusEnum? Status { get; set; }


        [JsonPropertyName("lotSizeFilter")]
        public LotSizeFilter? LotSizeFilter { get; set; }


        [JsonPropertyName("priceFilter")]
        public PriceFilter? PriceFilter { get; set; }


        [JsonPropertyName("leverageFilter")]
        public LeverageFilter? LeverageFilter { get; set; }


        [JsonPropertyName("contractType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ContractTypeEnum? ContractType { get; set; }


        [JsonPropertyName("launchTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime? LaunchTime { get; set; }


        [JsonPropertyName("deliveryTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime? DeliveryTime { get; set; }


        [JsonPropertyName("deliveryFeeRate")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? DeliveryFeeRate { get; set; }


        [JsonPropertyName("priceScale")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int? PriceScale { get; set; }


        [JsonPropertyName("unifiedMarginTrade")]
        public bool? UnifiedMarginTrade { get; set; }


        [JsonPropertyName("fundingInterval")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int? FundingInterval { get; set; }


        [JsonPropertyName("settleCoin")]
        public string? SettleCoin { get; set; }


        [JsonPropertyName("optionsType")]
        public string? OptionsType { get; set; }
    }

    public partial class LotSizeFilter
    {
        [JsonPropertyName("basePrecision")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? BasePrecision { get; set; }


        [JsonPropertyName("quotePrecision")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? QuotePrecision { get; set; }


        [JsonPropertyName("minOrderQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MinOrderQty { get; set; }


        [JsonPropertyName("maxOrderQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaxOrderQty { get; set; }


        [JsonPropertyName("minOrderAmt")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? MinOrderAmt { get; set; }


        [JsonPropertyName("qtyStep")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? QtyStep { get; set; }


        [JsonPropertyName("postOnlyMaxOrderQty")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? PostOnlyMaxOrderQty { get; set; }
    }

    public partial class PriceFilter
    {
        [JsonPropertyName("tickSize")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TickSize { get; set; }


        [JsonPropertyName("minPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? MinPrice { get; set; }


        [JsonPropertyName("maxPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal? MaxPrice { get; set; }
    }

    public partial class LeverageFilter
    {
        [JsonPropertyName("minLeverage")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int MinLeverage { get; set; }


        [JsonPropertyName("maxLeverage")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal MaxLeverage { get; set; }


        [JsonPropertyName("leverageStep")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal LeverageStep { get; set; }
    }
}
