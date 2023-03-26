using Bybit.Business.Abstract;
using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity.Models.Public;
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
                var result = await RequestHelper.SendRequestAsync($"{_prefix}/time", version: "v3", ct: ct);
                var data = JsonSerializer.Deserialize<ServerTimeModel>(result);

                if (data is not null)
                    return data.RetMsg == "OK"
                        ? new SuccessDataResult<ServerTimeData>(data.Result, data.RetMsg, data.RetCode)
                        : new ErrorDataResult<ServerTimeData>(data.RetMsg, data.RetCode);
                return new SuccessDataResult<ServerTimeData>();
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ServerTimeData>(ex.Message);
            }
        }
    }
}
