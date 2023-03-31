using Bybit.Core.Models;

namespace Bybit.Entity.Dtos.Market
{
    public class InsuranceDto : IBybitDto
    {
        /// <summary>
        /// coin. Default: return all insurance coins
        /// </summary>
        public string Coin { get; set; } = "";
    }
}
