using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity.Dtos.Market;
using Bybit.Entity.Models.Market;
using System.Text.Json;

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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}{url}", parameters, ct: ct);

                var data = JsonSerializer.Deserialize<KLineModel>(result);
                if (data is not null)
                    return data.RetMsg == "OK"
                        ? new SuccessDataResult<KLineData>(data.Result, data.RetMsg, data.RetCode)
                        : new ErrorDataResult<KLineData>(data.RetMsg, data.RetCode);
                return new SuccessDataResult<KLineData>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/instruments-info", parameters, ct: ct);

                var data = JsonSerializer.Deserialize<InstrumentsInfoModel>(result);

                return data is not null
                    ? data.RetMsg == "OK" || data.RetMsg == "success"
                       ? new SuccessDataResult<List<InstrumentsInfoDataList>>(data.Result?.InstrumentsInfoDataList, data.RetMsg, data.RetCode)
                       : new ErrorDataResult<List<InstrumentsInfoDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<InstrumentsInfoDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/orderbook", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<OrderBookModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                        ? new SuccessDataResult<OrderBookData>(data.Result, data.RetMsg, data.RetCode)
                        : new ErrorDataResult<OrderBookData>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<OrderBookData>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/tickers", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<TickerModel>(result);

                return data is not null
                    ? data.RetMsg == "OK" || data.RetMsg == "SUCCESS"
                     ? new SuccessDataResult<List<TickerDataList>>(data.Result?.TickerDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<TickerDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<TickerDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/funding/history", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<FundingRateHistoryModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                     ? new SuccessDataResult<List<FundingRateHistoryDataList>>(data.Result?.FundingRateHistoryDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<FundingRateHistoryDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<FundingRateHistoryDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/recent-trade", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<PublicTradingHistoryModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                     ? new SuccessDataResult<List<PublicTradingHistoryDataList>>(data.Result?.PublicTradingHistoryDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<PublicTradingHistoryDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<PublicTradingHistoryDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/open-interest", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<OpenInterestModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                     ? new SuccessDataResult<List<OpenInterestDataList>>(data.Result?.OpenInterestDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<OpenInterestDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<OpenInterestDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/historical-volatility", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<HistoricalVolatilityModel>(result);

                return data is not null
                    ? data.RetMsg == "SUCCESS"
                     ? new SuccessDataResult<List<HistoricalVolatilityData>>(data.Result, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<HistoricalVolatilityData>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<HistoricalVolatilityData>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/insurance", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<InsuranceModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                     ? new SuccessDataResult<List<InsuranceDataList>>(data.Result?.InsuranceDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<InsuranceDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<InsuranceDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/risk-limit", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<RiskLimitModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                        ? new SuccessDataResult<List<RiskLimitDataList>>(data.Result?.RiskLimitDataList, data.RetMsg, data.RetCode)
                        : new ErrorDataResult<List<RiskLimitDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<RiskLimitDataList>>();
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

                var result = await RequestHelper.SendRequestAsync($"{_prefix}/delivery-price", parameters, ct: ct);
                var data = JsonSerializer.Deserialize<DeliveryPriceModel>(result);

                return data is not null
                    ? data.RetMsg == "OK"
                     ? new SuccessDataResult<List<DeliveryPriceDataList>>(data.Result?.DeliveryPriceDataList, data.RetMsg, data.RetCode)
                     : new ErrorDataResult<List<DeliveryPriceDataList>>(data.RetMsg, data.RetCode)
                    : new SuccessDataResult<List<DeliveryPriceDataList>>();
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DeliveryPriceDataList>>(ex.Message);
            }
        }
    }
}
