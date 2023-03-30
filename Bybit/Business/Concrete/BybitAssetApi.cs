using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity;
using Bybit.Entity.Dtos.Asset;
using Bybit.Entity.Models.Asset;

namespace Bybit.Business.Concrete
{
    public class BybitAssetApi : IBybitAssetApi
    {
        private const string _prefix = "/asset";

        public async Task<IDataResult<SpotData>> GetAssetInfoAsync(BybitOptions options, AssetInfoDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["accountType"] = model.AccountType.GetDisplayName(),
                    ["coin"] = model.Coin,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<AssetInfoModel>(HttpMethod.Get, $"{_prefix}/transfer/query-asset-info", options, parameters, ct: ct);
                return result.Success && result.Data?.RetMsg == "success"
                    ? new SuccessDataResult<SpotData>(result.Data?.Result?.SpotData, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<SpotData>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<SpotData>(ex.Message);
            }
        }

        public async Task<IDataResult<AllCoinsBalanceData>> GetAllCoinsBalanceAsync(BybitOptions options, AllCoinsBalanceDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new AllCoinsBalanceDto();

                var parameters = new Dictionary<string, string>
                {
                    ["accountType"] = model.AccountType.GetDisplayName(),
                    ["coin"] = model.Coin,
                    ["memberId"] = model.MemberId,
                    ["withBonus"] = model.WithBonus ? "1" : "0",
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<AllCoinsBalanceModel>(HttpMethod.Get, $"{_prefix}/transfer/query-account-coins-balance", options, parameters, ct: ct);
                return result.Success && result.Data?.RetMsg == "success"
                    ? new SuccessDataResult<AllCoinsBalanceData>(result.Data?.Result, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<AllCoinsBalanceData>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AllCoinsBalanceData>(ex.Message);
            }
        }

        public async Task<IDataResult<SingleCoinBalanceData>> GetSingleCoinBalanceAsync(BybitOptions options, SingleCoinBalanceDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["accountType"] = model.AccountType.GetDisplayName(),
                    ["coin"] = model.Coin,
                    ["memberId"] = model.MemberId,
                    ["withBonus"] = model.WithBonus ? "1" : "0",
                    ["withTransferSafeAmount"] = model.WithTransferSafeAmount ? "1" : "0",
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<SingleCoinBalanceModel>(HttpMethod.Get, $"{_prefix}/transfer/query-account-coin-balance", options, parameters, ct: ct);
                return result.Success && result.Data?.RetMsg == "success"
                    ? new SuccessDataResult<SingleCoinBalanceData>(result.Data?.Result, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<SingleCoinBalanceData>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<SingleCoinBalanceData>(ex.Message);
            }
        }

        public async Task<IDataResult<List<CoinInfoDataRow>>> GetCoinInfoAsync(BybitOptions options, CoinInfoDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new CoinInfoDto();

                var parameters = new Dictionary<string, string>
                {
                    ["coin"] = model.Coin,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<CoinInfoModel>(HttpMethod.Get, $"{_prefix}/coin/query-info", options, parameters, ct: ct);
                return result.Data?.RetMsg == ""
                    ? new SuccessDataResult<List<CoinInfoDataRow>>(result.Data?.Result?.Rows, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<List<CoinInfoDataRow>>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CoinInfoDataRow>>(ex.Message);
            }
        }
    }
}
