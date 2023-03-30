using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Asset
{
    public class AssetInfoDto : IBybitDto
    {
        /// <summary>
        /// Account type. SPOT
        /// </summary>
        public AccountTypeEnum AccountType { get; set; }

        /// <summary>
        /// Coin name
        /// </summary>
        public string Coin { get; set; } = "";
    }
}
