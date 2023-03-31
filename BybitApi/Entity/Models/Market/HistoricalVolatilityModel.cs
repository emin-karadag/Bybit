using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class HistoricalVolatilityModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("result")]
        public List<HistoricalVolatilityData>? Result { get; set; }
    }

    public partial class HistoricalVolatilityData
    {
        [JsonPropertyName("period")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PeriodEnum Period { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Value { get; set; }

        [JsonPropertyName("time")]
        [JsonConverter(typeof(StringToDateTimeConvertor))]
        public DateTime Time { get; set; }
    }
}
