using Bybit.Core.Models;
using Bybit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
