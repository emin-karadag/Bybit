using Bybit.Core.Models;
using Bybit.Models.Enums;

namespace Bybit.Entity.Dtos.Trade
{
    public class PlaceOrderDto : IBybitDto
    {
        /// <summary>
        /// Product type
        /// - Unified account: spot, linear, inverse, option
        /// - Normal account: spot, linear, inverse
        /// </summary>
        public CategoryEnum Category { get; set; }

        /// <summary>
        /// Symbol name
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Buy, Sell
        /// </summary>
        public OrderSideEnum Side { get; set; }

        /// <summary>
        /// 	Market, Limit
        /// </summary>
        public OrderTypeEnum OrderType { get; set; }

        /// <summary>
        /// Order quantity. For Spot Market Buy order, please note that qty should be quote curreny amount
        /// </summary>
        public required string Quantity { get; set; }

        /// <summary>
        /// Whether to borrow. Valid for Unified spot only. 0(default): false then spot trading, 1: true then margin trading
        /// </summary>
        public bool IsLeverage { get; set; }

        /// <summary>
        /// Order price. If you have net position, price needs to be greater than liquidation price
        /// </summary>
        public string Price { get; set; } = "";

        /// <summary>
        /// Conditional order param. Used to identify the expected direction of the conditional order.
        /// - 1: triggered when market price rises to triggerPrice
        /// - 2: triggered when market price falls to triggerPrice
        /// </summary>
        public int TriggerDirection { get; set; }

        /// <summary>
        /// Valid for spot only. Order,tpslOrder. If not passed, Order by default
        /// </summary>
        public string OrderFilter { get; set; } = "";

        /// <summary>
        /// - For futures, it is the conditional order trigger price. If you expect the price to rise to trigger your conditional order, make sure: triggerPrice > market price Else, triggerPrice < market price
        /// - For spot, it is the TP/SL order trigger price
        /// </summary>
        public string TriggerPrice { get; set; } = "";

        /// <summary>
        /// Conditional order param. Trigger price type. LastPrice, IndexPrice, MarkPrice
        /// </summary>
        public TriggerByEnum TriggerBy { get; set; }

        /// <summary>
        /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
        /// </summary>
        public string OrderIv { get; set; } = "";

        /// <summary>
        /// - Market order will use IOC directly
        /// - If not passed, GTC is used by default
        /// </summary>
        public TimeInForceEnum TimeInForce { get; set; }

        /// <summary>
        /// Used to identify positions in different position modes. Under hedge-mode, this param is required
        /// - 0: one-way mode
        /// - 1: hedge-mode Buy side
        /// - 2: hedge-mode Sell side
        /// </summary>
        public PositionIdxEnum PositionIdx { get; set; }

        /// <summary>
        /// User customised order ID. A max of 36 characters. Combinations of numbers, letters (upper and lower cases), dashes, and underscores are supported.future orderLinkId rules:
        /// - optional param
        /// - The same orderLinkId can be used for both USDC PERP and USDT PERP.
        /// - An orderLinkId can be reused once the original order is either Filled or Cancelled
        /// option orderLinkId rules:
        /// - required param
        /// - always unique
        /// </summary>
        public string OrderLinkId { get; set; } = "";

        /// <summary>
        /// Take profit price
        /// </summary>
        public string TakeProfit { get; set; } = "";

        /// <summary>
        /// Stop loss price
        /// </summary>
        public string StopLoss { get; set; } = "";

        /// <summary>
        /// The price type to trigger take profit. MarkPrice, IndexPrice, default: LastPrice
        /// </summary>
        public TriggerByEnum TpTriggerBy { get; set; }

        /// <summary>
        /// The price type to trigger stop loss. MarkPrice, IndexPrice, default: LastPrice
        /// </summary>
        public TriggerByEnum SlTriggerBy { get; set; }

        /// <summary>
        /// What is a reduce-only order? true means your position can only reduce in size if this order is triggered. When reduce_only is true, take profit/stop loss cannot be set
        /// </summary>
        public bool? ReduceOnly { get; set; }

        /// <summary>
        /// What is a close on trigger order? For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.
        /// </summary>
        public bool? CloseOnTrigger { get; set; }

        /// <summary>
        /// Market maker protection. option only. true means set the order as a market maker protection order. What is mmp?
        /// </summary>
        public string Mmp { get; set; } = "";
    }
}
