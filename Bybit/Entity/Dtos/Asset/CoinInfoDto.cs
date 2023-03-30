using Bybit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
