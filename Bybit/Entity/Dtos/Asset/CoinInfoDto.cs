using Bybit.Core.Models;

namespace Bybit.Entity.Dtos.Asset
{
    public class CoinInfoDto : IBybitDto
    {
        /// <summary>
        /// Coin
        /// </summary>
        public string Coin { get; set; } = "";
    }
}
