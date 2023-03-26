using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class DeliveryPriceModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public DeliveryPriceData? Result { get; set; }
    }

    public partial class DeliveryPriceData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("list")]
        public List<DeliveryPriceDataList>? DeliveryPriceDataList { get; set; }

        [JsonPropertyName("nextPageCursor")]
        public string NextPageCursor { get; set; } = "";
    }

    public partial class DeliveryPriceDataList
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("deliveryPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal DeliveryPrice { get; set; }

        [JsonPropertyName("deliveryTime")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime DeliveryTime { get; set; }
    }
}
