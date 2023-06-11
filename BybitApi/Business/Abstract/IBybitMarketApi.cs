using Bybit.Core.Results.Abstract;
using Bybit.Entity.Dtos.Market;
using Bybit.Entity.Models.Market;

namespace Bybit.Business.Abstract
{
    public interface IBybitMarketApi
    {
        /// <summary>
        /// Query the kline data. Charts are returned in groups based on the requested interval.
        /// Covers: Spot / USDT and USDC perpetual / Inverse contract
        /// </summary>
        /// <param name="model">KLineDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<KLineData>> GetKLineAsync(KLineDto model, CancellationToken ct = default);

        /// <summary>
        /// Query the mark price kline data. Charts are returned in groups based on the requested interval.
        /// Covers: USDT and USDC perpetual / Inverse contract
        /// </summary>
        /// <param name="model">KLineDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<KLineData>> GetMarkPriceKLineAsync(KLineDto model, CancellationToken ct = default);

        /// <summary>
        /// Query the index price kline data. Charts are returned in groups based on the requested interval.
        /// Covers: USDT and USDC perpetual / Inverse contract
        /// </summary>
        /// <param name="model">KLineDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<KLineData>> GetIndexPriceKLineAsync(KLineDto model, CancellationToken ct = default);

        /// <summary>
        /// Retrieve the premium index price kline data. Charts are returned in groups based on the requested interval.
        /// Covers: USDT and USDC perpetual
        /// </summary>
        /// <param name="model">KLineDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<KLineData>> GetPremiumIndexPriceKLineAsync(KLineDto model, CancellationToken ct = default);

        /// <summary>
        /// Query a list of instruments of online trading pair.
        /// Covers: Spot / USDT and USDC perpetual / Inverse contract / Option
        /// CAUTION:
        /// - Spot does not support pagination, so limit, cursor are invalid.
        /// - When query by baseCoin, regardless of category=linear or inverse, the result will have USDT/USDC perpetual and Inverse contract symbols.
        /// </summary>
        /// <param name="model">InstrumentsInfoDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<InstrumentsInfoDataList>>> GetInstrumentsInfoAsync(InstrumentsInfoDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query orderbook data
        /// Covers: Spot / USDT and USDC perpetual / Inverse contract / Option
        /// - future: 200-level of orderbook data
        /// - spot: 50-level of orderbook data
        /// - option: 25-level of orderbook data
        /// </summary>
        /// <param name="model">OrderBookDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<OrderBookData>> GetOrderbookAsync(OrderBookDto model, CancellationToken ct = default);

        /// <summary>
        /// Query the latest price snapshot, best bid/ask price, and trading volume in the last 24 hours.
        /// Covers: Spot / USDT and USDC perpetual / Inverse contract / Option
        /// - If category=option, symbol or baseCoin must be passed.
        /// </summary>
        /// <param name="model">TickerDto?</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<TickerDataList>>> GetTickersAsync(TickerDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query historical funding rate. Each symbol has a different funding interval. For example, if the interval is 8 hours and the current time is UTC 12, then it returns the last funding rate, which settled at UTC 8. To query the funding rate interval, please refer to instruments-info.
        /// Covers: USDT and USDC perpetual / Inverse perpetual
        /// - Passing startTime only, it returns error.
        /// - Passing endTime only, it returns 200 records till endTime.
        /// - Both are not passed, it returns 200 records till current time.
        /// </summary>
        /// <param name="model">FundingRateHistoryDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<FundingRateHistoryDataList>>> GetFundingRateHistoryAsync(FundingRateHistoryDto model, CancellationToken ct = default);

        /// <summary>
        /// Query recent public trading data in Bybit.
        /// Covers: Spot / USDT perpetual / USDC contract / Inverse contract / Option
        /// </summary>
        /// <param name="model">PublicTradingHistoryDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<PublicTradingHistoryDataList>>> GetPublicTradingHistoryAsync(PublicTradingHistoryDto model, CancellationToken ct = default);

        /// <summary>
        /// Get open interest of each symbol.
        /// Covers: USDT perpetual / USDC contract / Inverse contract
        /// Returns single side data
        /// The upper limit time you can query is the launch time of the symbol.
        /// </summary>
        /// <param name="model">OpenInterestDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<OpenInterestDataList>>> GetOpenInterestAsync(OpenInterestDto model, CancellationToken ct = default);

        /// <summary>
        /// Query option historical volatility
        /// Covers: Option
        /// - The data is hourly.
        /// - If both startDate and endDate are not specified, it will return the most recent 1 hours worth of data by default.
        /// - startDate and endDate are a pair of params. Either both are passed or they are not passed at all.
        /// - This endpoint can query the last 2 years worth of data, but make sure [endDate - startDate] <= 30 days.
        /// </summary>
        /// <param name="model">HistoricalVolatilityDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<HistoricalVolatilityData>>> GetHistoricalVolatilityAsync(HistoricalVolatilityDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query Bybit insurance pool data (BTC/USDT/USDC etc). The data is updated every 24 hours.
        /// </summary>
        /// <param name="model">InsuranceDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<InsuranceDataList>>> GetInsuranceAsync(InsuranceDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query risk limit of futures
        /// Covers: USDT perpetual / USDC contract / Inverse contract
        /// </summary>
        /// <param name="model">RiskLimitDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<RiskLimitDataList>>> GetRiskLimitAsync(RiskLimitDto model, CancellationToken ct = default);

        /// <summary>
        /// Get the delivery price of Inverse futures, USDC futures and Options
        /// Covers: USDC futures / Inverse futures / Option
        /// </summary>
        /// <param name="model">DeliveryPriceDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<DeliveryPriceDataList>>> GetDeliveryPriceAsync(DeliveryPriceDto model, CancellationToken ct = default);
    }
}
