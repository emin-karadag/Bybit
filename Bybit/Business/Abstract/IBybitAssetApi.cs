using Bybit.Core.Results.Abstract;
using Bybit.Entity;
using Bybit.Entity.Dtos.Asset;
using Bybit.Entity.Models.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bybit.Business.Abstract
{
    public interface IBybitAssetApi
    {
        /// <summary>
        /// Query asset information
        /// - For now, it can query SPOT only.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">AssetInfoDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<SpotData>> GetAssetInfoAsync(BybitOptions options, AssetInfoDto model, CancellationToken ct = default);

        /// <summary>
        /// You could get all coin balance of all account types under the master account, and sub account.
        /// - It is not allowed to get master account coin balance via sub account api key.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">CoinBalanceDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<AllCoinsBalanceData>> GetAllCoinsBalanceAsync(BybitOptions options, AllCoinsBalanceDto? model = null, CancellationToken ct = default);

        /// <summary>
        /// Query the balance of a specific coin in a specific account type. Supports querying sub UID's balance.
        /// - Can query by the master UID's api key only
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="model">SingleCoinBalanceDto</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<SingleCoinBalanceData>> GetSingleCoinBalanceAsync(BybitOptions options, SingleCoinBalanceDto model, CancellationToken ct = default);

        /// <summary>
        /// Query coin information, including chain information, withdraw and deposit status.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="model"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<List<CoinInfoDataRow>>> GetCoinInfoAsync(BybitOptions options, CoinInfoDto? model = null, CancellationToken ct = default);
    }
}
