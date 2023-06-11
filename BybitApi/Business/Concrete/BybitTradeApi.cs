using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity;
using Bybit.Entity.Dtos.Trade;
using Bybit.Entity.Models.Trade;

namespace Bybit.Business.Concrete
{
    public class BybitTradeApi : IBybitTradeApi
    {
        private const string _prefix = "/order";

        public async Task<IDataResult<PlaceOrderData>> PlaceOrderAsync(BybitOptions options, PlaceOrderDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["isLeverage"] = model.IsLeverage ? "1" : "0",
                    ["side"] = model.Side.GetDisplayName(),
                    ["orderType"] = model.OrderType.GetDisplayName(),
                    ["qty"] = model.Quantity,
                    ["price"] = model.Price,
                    ["triggerDirection"] = model.TriggerDirection.ToString(),
                    ["orderFilter"] = model.OrderFilter,
                    ["triggerPrice"] = model.TriggerPrice,
                    ["triggerBy"] = model.TriggerBy.GetDisplayName(),
                    ["orderIv"] = model.OrderIv,
                    ["timeInForce"] = model.TimeInForce.GetDisplayName(),
                    ["positionIdx"] = model.PositionIdx.GetDisplayName(),
                    ["orderLinkId"] = model.OrderLinkId,
                    ["takeProfit"] = model.TakeProfit,
                    ["stopLoss"] = model.StopLoss,
                    ["tpTriggerBy"] = model.TpTriggerBy.GetDisplayName(),
                    ["slTriggerBy"] = model.SlTriggerBy.GetDisplayName(),
                    ["reduceOnly"] = string.IsNullOrEmpty(model.TakeProfit) && string.IsNullOrEmpty(model.StopLoss) ? model.ReduceOnly.ToString() : "false",
                    ["closeOnTrigger"] = string.IsNullOrEmpty(model.TakeProfit) && string.IsNullOrEmpty(model.StopLoss) ? model.CloseOnTrigger.ToString() : "false",
                    ["mmp"] = string.IsNullOrEmpty(model.Mmp) ? "false" : model.Mmp.ToString(),
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<PlaceOrderModel>(HttpMethod.Post, $"{_prefix}/create", options, parameters, ct: ct);
                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<PlaceOrderData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<PlaceOrderData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PlaceOrderData>(ex.Message);
            }
        }

        public async Task<IDataResult<AmendOrderData>> AmendOrderAsync(BybitOptions options, AmendOrderDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["orderId"] = model.OrderId,
                    ["qty"] = model.Quantity,
                    ["price"] = model.Price,
                    ["triggerPrice"] = model.TriggerPrice,
                    ["triggerBy"] = model.TriggerBy.GetDisplayName(),
                    ["orderIv"] = model.OrderIv,
                    ["orderLinkId"] = model.OrderLinkId,
                    ["takeProfit"] = model.TakeProfit,
                    ["stopLoss"] = model.StopLoss,
                    ["tpTriggerBy"] = model.TpTriggerBy.GetDisplayName(),
                    ["slTriggerBy"] = model.SlTriggerBy.GetDisplayName(),
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<AmendOrderModel>(HttpMethod.Post, $"{_prefix}/amend", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                   ? new SuccessDataResult<AmendOrderData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                   : new ErrorDataResult<AmendOrderData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AmendOrderData>(ex.Message);
            }
        }

        public async Task<IDataResult<CancelOrderData>> CancelOrderAsync(BybitOptions options, CancelOrderDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["orderId"] = model.OrderId,
                    ["orderLinkId"] = model.OrderLinkId,
                    ["orderFilter"] = model.OrderFilter,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<CancelOrderModel>(HttpMethod.Post, $"{_prefix}/cancel", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                  ? new SuccessDataResult<CancelOrderData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<CancelOrderData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CancelOrderData>(ex.Message);
            }
        }

        public async Task<IDataResult<OpenOrdersData>> GetOpenOrdersAsync(BybitOptions options, OpenOrdersDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new OpenOrdersDto();

                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["baseCoin"] = model.BaseCoin,
                    ["settleCoin"] = model.SettleCoin,
                    ["orderId"] = model.OrderId,
                    ["orderLinkId"] = model.OrderLinkId,
                    ["openOnly"] = model.OpenOnly.ToString(),
                    ["orderFilter"] = model.OrderFilter,
                    ["limit"] = model.Limit.ToString(),
                    ["cursor"] = model.Cursor
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<OpenOrdersModel>(HttpMethod.Get, $"{_prefix}/realtime", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                  ? new SuccessDataResult<OpenOrdersData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<OpenOrdersData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OpenOrdersData>(ex.Message);
            }
        }

        public async Task<IDataResult<CancelAllOrdersData>> CancelAllOrdersAsync(BybitOptions options, CancelAllOrdersDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new CancelAllOrdersDto();

                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["baseCoin"] = model.BaseCoin,
                    ["settleCoin"] = model.SettleCoin,
                    ["orderFilter"] = model.OrderFilter,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<CancelAllOrdersModel>(HttpMethod.Post, $"{_prefix}/cancel-all", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                 ? new SuccessDataResult<CancelAllOrdersData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                 : new ErrorDataResult<CancelAllOrdersData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<CancelAllOrdersData>(ex.Message);
            }
        }

        public async Task<IDataResult<OrderHistoryData>> GetOrderHistoryAsync(BybitOptions options, OrderHistoryDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new OrderHistoryDto();

                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["baseCoin"] = model.BaseCoin,
                    ["orderId"] = model.OrderId,
                    ["orderLinkId"] = model.OrderLinkId,
                    ["orderFilter"] = model.OrderFilter,
                    ["orderStatus"] = model.OrderStatus?.GetDisplayName() ?? "",
                    ["limit"] = model.Limit.ToString(),
                    ["cursor"] = model.Cursor
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<OrderHistoryModel>(HttpMethod.Get, $"{_prefix}/history", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<OrderHistoryData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<OrderHistoryData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderHistoryData>(ex.Message);
            }
        }

        public async Task<IDataResult<BorrowQuotaData>> GetBorrowQuotaAsync(BybitOptions options, BorrowQuotaDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["side"] = model.Side.GetDisplayName(),
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<BorrowQuotaModel>(HttpMethod.Get, $"{_prefix}/spot-borrow-check", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<BorrowQuotaData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<BorrowQuotaData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<BorrowQuotaData>(ex.Message);
            }
        }
    }
}
