using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Market
{
    public class OrderBookModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public OrderBookData? Result { get; set; }
    }

    public partial class OrderBookData
    {
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("a")]
        public List<List<string>>? Asks { get; set; }

        [JsonPropertyName("b")]
        public List<List<string>>? Bids { get; set; }

        [JsonPropertyName("ts")]
        [JsonConverter(typeof(LongToDateTimeConvertor))]
        public DateTime Ts { get; set; }

        [JsonPropertyName("u")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long UpdateId { get; set; }
    }
}
