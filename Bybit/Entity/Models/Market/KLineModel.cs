using Bybit.Core.Models;
using Bybit.Models.Common;
using Bybit.Models.Enums;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class KLineModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public KLineData? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }
    }

    public partial class KLineData
    {
        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryEnum? Category { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("list")]
        public List<List<string>>? List { get; set; }
    }
}
