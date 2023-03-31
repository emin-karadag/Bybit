using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Account
{
    public class WalletBalanceDto : IBybitDto
    {
        /// <summary>
        /// - Unified account: UNIFIED (trade spot/linear/options), CONTRACT(trade inverse)
        /// - Normal account: CONTRACT, SPOT
        /// </summary>
        public AccountTypeEnum AccountType { get; set; }

        /// <summary>
        /// - If not passed, it returns non-zero asset info
        /// - You can pass multiple coins to query, separated by comma. USDT,USDC
        /// </summary>
        public string Coin { get; set; } = "";
    }
}
