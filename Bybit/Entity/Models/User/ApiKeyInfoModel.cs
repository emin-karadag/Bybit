using Bybit.Core.Converters;
using Bybit.Core.Models;
using System.Text.Json.Serialization;

namespace Bybit.Entity.Models.User
{
    public class ApiKeyInfoModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public ApiKeyInfoData? Result { get; set; }
    }

    public partial class ApiKeyInfoData
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Id { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; } = "";

        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; } = "";

        [JsonPropertyName("readOnly")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int ReadOnly { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; } = "";

        [JsonPropertyName("permissions")]
        public Permissions? Permissions { get; set; }

        [JsonPropertyName("ips")]
        public List<string>? Ips { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int? Type { get; set; }

        [JsonPropertyName("deadlineDay")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int DeadlineDay { get; set; }

        [JsonPropertyName("expiredAt")]
        public DateTimeOffset ExpiredAt { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("unified")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Unified { get; set; }

        [JsonPropertyName("uta")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Uta { get; set; }

        [JsonPropertyName("userID")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long UserId { get; set; }

        [JsonPropertyName("inviterID")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long InviterId { get; set; }

        [JsonPropertyName("vipLevel")]
        public string VipLevel { get; set; } = "";

        [JsonPropertyName("mktMakerLevel")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int MktMakerLevel { get; set; }

        [JsonPropertyName("affiliateID")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long AffiliateId { get; set; }

        [JsonPropertyName("rsaPublicKey")]
        public string RsaPublicKey { get; set; } = "";

        [JsonPropertyName("isMaster")]
        public bool IsMaster { get; set; }
    }

    public partial class Permissions
    {
        [JsonPropertyName("ContractTrade")]
        public List<string>? ContractTrade { get; set; }

        [JsonPropertyName("Spot")]
        public List<string>? Spot { get; set; }

        [JsonPropertyName("Wallet")]
        public List<string>? Wallet { get; set; }

        [JsonPropertyName("Options")]
        public List<string>? Options { get; set; }

        [JsonPropertyName("Derivatives")]
        public List<string>? Derivatives { get; set; }

        [JsonPropertyName("CopyTrading")]
        public List<string>? CopyTrading { get; set; }

        [JsonPropertyName("BlockTrade")]
        public List<string>? BlockTrade { get; set; }

        [JsonPropertyName("Exchange")]
        public List<string>? Exchange { get; set; }

        [JsonPropertyName("NFT")]
        public List<string>? Nft { get; set; }
    }
}
