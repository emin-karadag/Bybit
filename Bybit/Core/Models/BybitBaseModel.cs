using Bybit.Core.Converters;
using System.Text.Json.Serialization;

namespace Bybit.Core.Models
{
    public abstract class BybitBaseModel
    {
        [JsonPropertyName("retCode")]
        public long RetCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string? RetMsg { get; set; }

        [JsonPropertyName("time")]
        [JsonConverter(typeof(LongToDateTimeConvertor))]
        public DateTime Date { get; set; }
    }
}
