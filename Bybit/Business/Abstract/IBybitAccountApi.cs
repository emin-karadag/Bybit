using Bybit.Core.Results.Abstract;
using Bybit.Entity;
using Bybit.Entity.Dtos.Account;
using Bybit.Entity.Models.Account;

namespace Bybit.Business.Abstract
{
    public interface IBybitAccountApi
    {
        /// <summary>
        /// Obtain wallet balance, query asset information of each currency, and account risk rate information. By default, currency information with assets or liabilities of 0 is not returned.
        /// - The trading of UTA inverse contracts is conducted through the CONTRACT wallet.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">WalletBalanceDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<WalletBalanceDataList>?>> GetWalletBalanceAsync(BybitOptions options, WalletBalanceDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Get the trading fee rate.
        /// - Covers: Spot / USDT perpetual / Inverse perpetual / Inverse futures / Options
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">FeeRateDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<FeeRateDataList>?>> GetFeeRateAsync(BybitOptions options, FeeRateDto model, CancellationToken ct = default);

        /// <summary>
        /// Query the margin mode configuration of the account.
        /// - Query the margin mode and the upgraded status of account
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<AccountInfoData>> GetAccountInfoAsync(BybitOptions options, CancellationToken ct = default);
    }
}
