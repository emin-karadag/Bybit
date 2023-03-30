using Bybit.Core.Models;
using Bybit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Entity.Dtos.Asset
{
    public class SingleCoinBalanceDto : IBybitDto
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
        public required string Coin { get; set; }

        /// <summary>
        /// Whether query bonus or not. Default：false
        /// </summary>
        public bool WithBonus { get; set; }

        /// <summary>
        /// Whether query delay withdraw/transfer safe amount. Default: false
        /// </summary>
        public bool WithTransferSafeAmount { get; set; }
    }
}
