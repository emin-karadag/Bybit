using Bybit.Core.Converters;
using Bybit.Core.Models;
using Bybit.Entity.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bybit.Entity.Models.User
{
    public class SubUIDListModel : BybitBaseModel, IBybitModel
    {
        [JsonPropertyName("result")]
        public SubUIDListData? Result { get; set; }
    }

    public partial class SubUIDListData
    {
        [JsonPropertyName("subMembers")]
        public List<SubMember>? SubMembers { get; set; }
    }

    public partial class SubMember
    {
        [JsonPropertyName("uid")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Uid { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; } = "";

        [JsonPropertyName("memberType")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int MemberType { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Status { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; } = "";
    }
}
