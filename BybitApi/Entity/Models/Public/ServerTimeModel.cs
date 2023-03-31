using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Public
{
    public class ServerTimeModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public ServerTimeData? Result { get; set; }
    }

    public partial class ServerTimeData
    {
        [JsonPropertyName("timeSecond")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long TimeSecond { get; set; }

        [JsonPropertyName("timeNano")]
        public string TimeNano { get; set; } = "";
    }
}
