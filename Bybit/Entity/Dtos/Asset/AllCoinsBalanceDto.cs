using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Asset
{
    public class AllCoinsBalanceDto : IBybitDto
    {
        /// <summary>
        /// Account type
        /// </summary>
        public AccountTypeEnum AccountType { get; set; }

        /// <summary>
        /// User Id. It is required when you use master api key to check sub account coin balance
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// Coin name
        /// - Query all coins if not passed
        /// - Can query multiple coins, separated by comma. USDT,USDC,ETH
        /// </summary>
        public string Coin { get; set; } = "";

        /// <summary>
        /// Whether query bonus or not. Default：false
        /// </summary>
        public bool WithBonus { get; set; }
    }
}
