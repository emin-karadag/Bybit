using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity;
using Bybit.Entity.Dtos.Account;
using Bybit.Entity.Models.Account;

namespace Bybit.Business.Concrete
{
    public class BybitAccountApi : IBybitAccountApi
    {
        private const string _prefix = "/account";

        public async Task<IDataResult<List<WalletBalanceDataList>?>> GetWalletBalanceAsync(BybitOptions options, WalletBalanceDto? model = null, CancellationToken ct = default)
        {
            try
            {
                model ??= new WalletBalanceDto();

                var parameters = new Dictionary<string, string>
                {
                    ["accountType"] = model.AccountType.GetDisplayName(),
                    ["coin"] = model.Coin,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<WalletBalanceModel>(HttpMethod.Get, $"{_prefix}/wallet-balance", options, parameters, ct: ct);
                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<List<WalletBalanceDataList>?>(result.Data?.Result?.WalletBalanceDataList, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<List<WalletBalanceDataList>?>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<WalletBalanceDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<FeeRateDataList>?>> GetFeeRateAsync(BybitOptions options, FeeRateDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["category"] = model.Category.GetDisplayName(),
                    ["symbol"] = model.Symbol,
                    ["baseCoin"] = model.BaseCoin,
                };

                var result = await RequestHelper.SendRequestWithAuthAsync<FeeRateModel>(HttpMethod.Get, $"{_prefix}/fee-rate", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<List<FeeRateDataList>?>(result.Data?.Result?.FeeRateDataList, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<List<FeeRateDataList>?>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<FeeRateDataList>>(ex.Message);
            }
        }

        public async Task<IDataResult<AccountInfoData>> GetAccountInfoAsync(BybitOptions options, CancellationToken ct = default)
        {
            try
            {
                var result = await RequestHelper.SendRequestWithAuthAsync<AccountInfoModel>(HttpMethod.Get, $"{_prefix}/info", options, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<AccountInfoData>(result.Data?.Result, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<AccountInfoData>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AccountInfoData>(ex.Message);
            }
        }
    }
}
