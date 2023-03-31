using System.Text.Json.Serialization;

namespace Bybit.Models.Common
{
    public class ErrorModel
    {
        [JsonPropertyName("retCode")]
        public int RetCode { get; set; }

        [JsonPropertyName("retMsg")]
        public string RetMsg { get; set; } = "";

        [JsonPropertyName("result")]
        public Result? Result { get; set; }

        [JsonPropertyName("retExtInfo")]
        public RetExtInfo? RetExtInfo { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }

    public class Result
    {
    }

    public class RetExtInfo
    {
    }
}
