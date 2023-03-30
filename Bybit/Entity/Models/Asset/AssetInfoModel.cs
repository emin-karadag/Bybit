using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.Asset
{
    public class AssetInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public AssetInfoData? Result { get; set; }
    }

    public partial class AssetInfoData
    {
        [JsonPropertyName("spot")]
        public SpotData? SpotData { get; set; }
    }

    public partial class SpotData
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";

        [JsonPropertyName("assets")]
        public List<Asset>? Assets { get; set; }
    }

    public partial class Asset
    {
        [JsonPropertyName("coin")]
        public string Coin { get; set; } = "";

        [JsonPropertyName("frozen")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Frozen { get; set; }

        [JsonPropertyName("free")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Free { get; set; }

        [JsonPropertyName("withdraw")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? Withdraw { get; set; }
    }
}
