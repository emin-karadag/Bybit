using Bybit.Core.Results.Abstract;
using Bybit.Entity.Dtos.Account;
using Bybit.Entity.Models.Account;
using Bybit.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BybitApi.Entity.Dtos.Position;
using BybitApi.Entity.Models.Position;

namespace BybitApi.Business.Abstract
{
    public interface IBybitPositionApi
    {
        Task<IDataResult<List<PositionInfoDataList>>> GetPositionInfoAsync(BybitOptions options, PositionDto model, CancellationToken ct = default);
    }
}
