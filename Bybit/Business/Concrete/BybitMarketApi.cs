using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity.Dtos.Market;
using Bybit.Entity.Models.Market;

namespace Bybit.Business.Concrete
{
    public class BybitMarketApi : IBybitMarketApi
    {
        private const string _prefix = "/market";

        public async Task<IDataResult<KLineData>> GetKLineAsync(KLineDto model, CancellationToken ct = default)
        {
            return await GetKLineAsync(model, "/kline", ct);
        }

        public async Task<IDataResult<KLineData>> GetMarkPriceKLineAsync(KLineDto model, CancellationToken ct = default)
        {
            return await GetKLineAsync(model, "/mark-price-kline", ct);
        }

        public async Task<IDataResult<KLineData>> GetIndexPriceKLineAsync(KLineDto model, CancellationToken ct = default)
        {
            return await GetKLineAsync(model, "/index-price-kline", ct);
        }

        public async Task<IDataResult<KLineData>> GetPremiumIndexPriceKLineAsync(KLineDto model, CancellationToken ct = default)
        {
            return await GetKLineAsync(model, "/premium-index-price-kline", ct);
        }

        private static async Task<IDataResult<KLineData>> GetKLineAsync(KLineDto model, string url, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["interval"] = model.Interval.GetDisplayName(),
                    ["limit"] = model.Limit.ToString(),
                };

                if (model.StartDate.HasValue && model.EndDate.HasValue)
                {
                    parameters["start"] = BybitHelper.GetTimestamp(model.StartDate.Value).ToString();
                    parameters["end"] = BybitHelper.GetTimestamp(model.EndDate.Value).ToString();
                }

                var result = await RequestHelper.SendRequestAsync<KLineModel>($"{_prefix}{url}", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<KLineData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<KLineData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<KLineData>(ex.Message);
            }
        }

        public async Task<IDataResult<List<InstrumentsInfoDataList>>> GetInstrumentsInfoAsync(InstrumentsInfoDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["limit"] = model.Limit.ToString(),
                    ["baseCoin"] = model.BaseCoin,
                };

                if (model.Cursor)
                    parameters["cursor"] = "true";

                var result = await RequestHelper.SendRequestAsync<InstrumentsInfoModel>($"{_prefix}/instruments-info", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK" || result.Data?.RetMsg == "success"
                    ? new SuccessDataResult<List<InstrumentsInfoDataList>>(result.Data.Result?.InstrumentsInfoDataList, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<List<InstrumentsInfoDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<InstrumentsInfoDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<OrderBookData>> GetOrderbookAsync(OrderBookDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["limit"] = model.Limit.ToString()
                };

                var result = await RequestHelper.SendRequestAsync<OrderBookModel>($"{_prefix}/orderbook", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<OrderBookData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<OrderBookData>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<OrderBookData>(ex.Message);
            }
        }

        public async Task<IDataResult<List<TickerDataList>>> GetTickersAsync(TickerDto? model, CancellationToken ct = default)
        {
            try
            {
                model ??= new TickerDto();

                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["baseCoin"] = model.BaseCoin,
                    ["expDate"] = model.ExpDate,
                };

                var result = await RequestHelper.SendRequestAsync<TickerModel>($"{_prefix}/tickers", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK" || result.Data?.RetMsg == "SUCCESS"
                   ? new SuccessDataResult<List<TickerDataList>>(result.Data.Result?.TickerDataList, result.Data.RetMsg, result.Data.RetCode)
                   : new ErrorDataResult<List<TickerDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<TickerDataList>>(ex.Message);
            }

        }

        public async Task<IDataResult<List<FundingRateHistoryDataList>>> GetFundingRateHistoryAsync(FundingRateHistoryDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["limit"] = model.Limit.ToString()
                };

                if (model.StartDate.HasValue)
                    parameters["startTime"] = BybitHelper.GetTimestamp(model.StartDate.Value).ToString();

                if (model.EndDate.HasValue)
                    parameters["endTime"] = BybitHelper.GetTimestamp(model.EndDate.Value).ToString();

                var result = await RequestHelper.SendRequestAsync<FundingRateHistoryModel>($"{_prefix}/funding/history", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                   ? new SuccessDataResult<List<FundingRateHistoryDataList>>(result.Data.Result?.FundingRateHistoryDataList, result.Data.RetMsg, result.Data.RetCode)
                   : new ErrorDataResult<List<FundingRateHistoryDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<FundingRateHistoryDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<PublicTradingHistoryDataList>>> GetPublicTradingHistoryAsync(PublicTradingHistoryDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["limit"] = model.Limit.ToString(),
                    ["baseCoin"] = model.BaseCoin.ToString(),
                    ["optionType"] = model.OptionType.ToString()
                };

                var result = await RequestHelper.SendRequestAsync<PublicTradingHistoryModel>($"{_prefix}/recent-trade", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                   ? new SuccessDataResult<List<PublicTradingHistoryDataList>>(result.Data.Result?.PublicTradingHistoryDataList, result.Data.RetMsg, result.Data.RetCode)
                   : new ErrorDataResult<List<PublicTradingHistoryDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PublicTradingHistoryDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<OpenInterestDataList>>> GetOpenInterestAsync(OpenInterestDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["symbol"] = model.Symbol,
                    ["category"] = model.Category.GetDisplayName(),
                    ["intervalTime"] = model.IntervalTime,
                    ["limit"] = model.Limit.ToString(),
                    ["cursor"] = model.Cursor.ToString(),
                };

                if (model.StartDate.HasValue)
                    parameters["startTime"] = BybitHelper.GetTimestamp(model.StartDate.Value).ToString();

                if (model.EndDate.HasValue)
                    parameters["endTime"] = BybitHelper.GetTimestamp(model.EndDate.Value).ToString();

                var result = await RequestHelper.SendRequestAsync<OpenInterestModel>($"{_prefix}/open-interest", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                  ? new SuccessDataResult<List<OpenInterestDataList>>(result.Data.Result?.OpenInterestDataList, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<List<OpenInterestDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<OpenInterestDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<HistoricalVolatilityData>>> GetHistoricalVolatilityAsync(HistoricalVolatilityDto? model, CancellationToken ct = default)
        {
            try
            {
                model ??= new HistoricalVolatilityDto();

                var parameters = new Dictionary<string, string>
                {
                    ["category"] = "option",
                    ["baseCoin"] = model.BaseCoin
                };

                if (model.Period.HasValue)
                    parameters["period"] = model.Period.GetDisplayName();

                if (model.StartDate.HasValue)
                    parameters["startTime"] = BybitHelper.GetTimestamp(model.StartDate.Value).ToString();

                if (model.EndDate.HasValue)
                    parameters["endTime"] = BybitHelper.GetTimestamp(model.EndDate.Value).ToString();

                var result = await RequestHelper.SendRequestAsync<HistoricalVolatilityModel>($"{_prefix}/historical-volatility", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "SUCCESS"
                  ? new SuccessDataResult<List<HistoricalVolatilityData>>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<List<HistoricalVolatilityData>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<HistoricalVolatilityData>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<InsuranceDataList>>> GetInsuranceAsync(InsuranceDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new InsuranceDto();

                var parameters = new Dictionary<string, string>
                {
                    ["coin"] = model.Coin
                };

                var result = await RequestHelper.SendRequestAsync<InsuranceModel>($"{_prefix}/insurance", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                  ? new SuccessDataResult<List<InsuranceDataList>>(result.Data.Result?.InsuranceDataList, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<List<InsuranceDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<InsuranceDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<RiskLimitDataList>>> GetRiskLimitAsync(RiskLimitDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["category"] = model.Category.GetDisplayName(),
                    ["symbol"] = model.Symbol
                };

                var result = await RequestHelper.SendRequestAsync<RiskLimitModel>($"{_prefix}/risk-limit", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                  ? new SuccessDataResult<List<RiskLimitDataList>>(result.Data.Result?.RiskLimitDataList, result.Data.RetMsg, result.Data.RetCode)
                  : new ErrorDataResult<List<RiskLimitDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<RiskLimitDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<DeliveryPriceDataList>>> GetDeliveryPriceAsync(DeliveryPriceDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["category"] = model.Category.GetDisplayName(),
                    ["symbol"] = model.Symbol,
                    ["baseCoin"] = model.BaseCoin,
                    ["limit"] = model.Limit.ToString(),
                    ["cursor"] = model.Cursor
                };

                var result = await RequestHelper.SendRequestAsync<DeliveryPriceModel>($"{_prefix}/delivery-price", parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                 ? new SuccessDataResult<List<DeliveryPriceDataList>>(result.Data.Result?.DeliveryPriceDataList, result.Data.RetMsg, result.Data.RetCode)
                 : new ErrorDataResult<List<DeliveryPriceDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DeliveryPriceDataList>>(ex.Message);
            }
        }
    }
}
