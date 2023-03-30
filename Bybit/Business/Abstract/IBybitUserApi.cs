using Bybit.Core.Results.Abstract;
using Bybit.Entity;
using Bybit.Entity.Models.User;

namespace Bybit.Business.Abstract
{
    public interface IBybitUserApi
    {
        /// <summary>
        /// Get all sub uid of master account. Use master user's api key only.
        /// The API key must own one of permissions will be allowed to call the following API endpoint.
        /// - master API key: "Account Transfer", "Subaccount Transfer", "Withdrawal"
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<List<SubMember>?>> GetSubUIDListAsync(BybitOptions options, CancellationToken ct = default);

        /// <summary>
        /// Get the information of the api key. Use the api key pending to be checked to call the endpoint. Both master and sub user's api key are applicable.
        /// - Any permission can access this endpoint.
        /// </summary>
        /// <param name="options">BybitOptions</param>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<ApiKeyInfoData?>> GetApiKeyInformationAsync(BybitOptions options, CancellationToken ct = default);
    }
}
