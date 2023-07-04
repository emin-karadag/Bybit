using Bybit.Core.Results.Abstract;
using Bybit.Core.Results.Concrete;
using Bybit.Core.Utilities;
using Bybit.Entity;
using Bybit.Entity.Models.Account;
using BybitApi.Business.Abstract;
using BybitApi.Entity.Dtos.Position;
using BybitApi.Entity.Models.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BybitApi.Business.Concrete
{
    public class BybitPositionApi : IBybitPositionApi
    {
        private const string _prefix = "/position";

        public async Task<IDataResult<List<PositionInfoDataList>>> GetPositionInfoAsync(BybitOptions options, PositionDto model, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    ["category"] = model.Category.GetDisplayName(),
                    ["symbol"] = model.Symbol,
                    ["baseCoin"] = model.BaseCoin,
                    ["settleCoin"] = model.SettleCoin,
                    ["limit"] = model.Limit.ToString(),
                    ["cursor"] = model.Cursor,
                };

                var result2 = await RequestHelper.SendRequestWithAuthAsync(HttpMethod.Get, $"{_prefix}/list", options, parameters, ct: ct);
                var result = await RequestHelper.SendRequestWithAuthAsync<PositionInfoModel>(HttpMethod.Get, $"{_prefix}/list", options, parameters, ct: ct);

                return result.Success && result.Data?.RetMsg == "OK"
                    ? new SuccessDataResult<List<PositionInfoDataList>>(result.Data?.Result?.Positions, result.Data?.RetMsg ?? "", result.Data?.RetCode ?? 0)
                    : new ErrorDataResult<List<PositionInfoDataList>>(result.Data?.RetMsg ?? result.Message, result.Data?.RetCode ?? 0);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PositionInfoDataList>>(ex.Message);
            }
        }
    }
}
