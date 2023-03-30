using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity;
using Bybit.Entity.Models.User;

namespace Bybit.Business.Concrete
{
    public class BybitUserApi : IBybitUserApi
    {
        private const string _prefix = "/user";

        public async Task<IDataResult<List<SubMember>?>> GetSubUIDListAsync(BybitOptions options, CancellationToken ct = default)
        {
            try
            {
                var result = await RequestHelper.SendRequestWithAuthAsync<SubUIDListModel>(HttpMethod.Get, $"{_prefix}/query-sub-members", options, ct: ct);
                return result.Data?.RetMsg == ""
                    ? new SuccessDataResult<List<SubMember>?>(result.Data?.Result?.SubMembers, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<List<SubMember>?>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SubMember>?>(ex.Message);
            }
        }

        public async Task<IDataResult<ApiKeyInfoData?>> GetApiKeyInformationAsync(BybitOptions options, CancellationToken ct = default)
        {
            try
            {
                var result = await RequestHelper.SendRequestWithAuthAsync<ApiKeyInfoModel>(HttpMethod.Get, $"{_prefix}/query-api", options, ct: ct);
                return result.Data?.RetMsg == ""
                    ? new SuccessDataResult<ApiKeyInfoData?>(result.Data?.Result, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<ApiKeyInfoData?>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ApiKeyInfoData?>(ex.Message);
            }
        }
    }
}
