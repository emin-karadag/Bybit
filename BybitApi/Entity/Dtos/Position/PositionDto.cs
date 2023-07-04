using Bybit.Core.Models;
using Bybit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BybitApi.Entity.Dtos.Position
{
    public class PositionDto : IBybitDto
    {
        /// <summary>
        /// Product type
        /// Unified account: linear, inverse, option
        /// Normal account: linear, inverse. Please note that category is not involved with business logic
        /// </summary>
        public required CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// If symbol passed, it returns data regardless of having position or not.
        /// If symbol=null and settleCoin specified, it returns position size greater than zero.
        /// </summary>
        public string Symbol { get; set; } = "";

        /// <summary>
        /// Base coin. option only. Return all option positions if not passed
        /// </summary>
        public string BaseCoin { get; set; } = "";

        /// <summary>
        /// Settle coin. For linear & inverse, either symbol or settleCoin is required. symbol has a higher priority
        /// </summary>
        public string SettleCoin { get; set; } = "";

        /// <summary>
        /// Limit for data size per page. [1, 200]. Default: 20
        /// </summary>
        public int Limit { get; set; } = 20;

        /// <summary>
        /// Cursor. Use the nextPageCursor token from the response to retrieve the next page of the result set
        /// </summary>
        public string Cursor { get; set; } = "";
    }
}
