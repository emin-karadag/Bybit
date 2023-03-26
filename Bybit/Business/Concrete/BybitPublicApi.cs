using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity.Models.Public;
using Bybit.Entity.Models.Trade;
using System.Text.Json;

namespace Bybit.Business.Concrete
{
    public class BybitPublicApi : IBybitPublicApi
    {
        private const string _prefix = "/public";

        public async Task<IDataResult<ServerTimeData>> GetServerTimeAsync(CancellationToken ct = default)
        {
            try
            {
                var result = await RequestHelper.SendRequestAsync<ServerTimeModel>($"{_prefix}/time", version: "v3", ct: ct);
                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<ServerTimeData>(result.Data.Result, result.Data.RetMsg, result.Data.RetCode)
                    : new ErrorDataResult<ServerTimeData>(result.Data?.RetMsg, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ServerTimeData>(ex.Message);
            }
        }
    }
}
