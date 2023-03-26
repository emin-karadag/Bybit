using Bybit.Core.Results.Abstract;
using Bybit.Entity.Models.Public;

namespace Bybit.Business.Abstract
{
    public interface IBybitPublicApi
    {
        /// <summary>
        /// Get the Bybit server timestamp
        /// </summary>
        /// <param name="ct">CancellationToken</param>
        /// <returns></returns>
        Task<IDataResult<ServerTimeData>> GetServerTimeAsync(CancellationToken ct = default);
    }
}
