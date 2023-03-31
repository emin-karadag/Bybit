using Bybit.Core.Results.Abstract;
using Bybit.Entity;
using Bybit.Entity.Dtos.Trade;
using Bybit.Entity.Models.Trade;

namespace Bybit.Business.Abstract
{
    public interface IBybitTradeApi
    {
        /// <summary>
        /// This endpoint supports to create the order for spot, spot margin, USDT perpetual, USDC perpetual, USDC futures, inverse futures and options.
        /// - Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// - Normal account covers: Spot / USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">PlaceOrderDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<PlaceOrderData>> PlaceOrderAsync(BybitOptions options, PlaceOrderDto model, CancellationToken ct = default);

        /// <summary>
        /// Unified account covers: USDT perpetual / USDC contract / Inverse contract / Options
        /// Normal account covers: USDT perpetual / Inverse contract
        /// - You can modify unfilled or partially filled orders.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">AmendOrderDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<AmendOrderData>> AmendOrderAsync(BybitOptions options, AmendOrderDto model, CancellationToken ct = default);

        /// <summary>
        /// Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// Normal account covers: Spot / USDT perpetual / Inverse contract
        /// - You must specify orderId or orderLinkId to cancel the order.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">CancelOrderDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<CancelOrderData>> CancelOrderAsync(BybitOptions options, CancelOrderDto model, CancellationToken ct = default);

        /// <summary>
        /// Query unfilled or partially filled orders in real-time. 
        /// - Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// - Normal account covers: Spot / USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="options"></param>
        /// <param name="model"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<OpenOrdersData>> GetOpenOrdersAsync(BybitOptions options, OpenOrdersDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Cancel all open orders
        /// - Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// - Normal account covers: Spot / USDT perpetual / Inverse contract
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">CancelAllOrdersDto</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<CancelAllOrdersData>> CancelAllOrdersAsync(BybitOptions options, CancelAllOrdersDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query order history. As order creation/cancellation is asynchronous, the data returned from this endpoint may delay.
        /// - Unified account covers: Spot / USDT perpetual / USDC contract / Inverse contract / Options
        /// - Normal account covers: Spot / USDT perpetual / Inverse contract
        /// - You can query by symbol, baseCoin, orderId and orderLinkId, and if you pass multiple params, the system will process them according to this priority: orderId > orderLinkId > symbol > baseCoin.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">OrderHistoryDto</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<OrderHistoryData>> GetOrderHistoryAsync(BybitOptions options, OrderHistoryDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query the qty and amount of borrowable coins in spot account.
        /// - Covers: Spot (Unified Account)
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">BorrowQuotaDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<BorrowQuotaData>> GetBorrowQuotaAsync(BybitOptions options, BorrowQuotaDto model, CancellationToken ct = default);
    }
}
