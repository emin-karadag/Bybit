using Bybit.Business.Abstract;
using System.ComponentModel;

namespace Bybit.Business.Concrete
{
    public class BybitManager : IBybitService
    {
        public BybitManager()
        {
            Public = new BybitPublicApi();
            Market = new BybitMarketApi();
            Trade = new BybitTradeApi();
            Account = new BybitAccountApi();
            Asset = new BybitAssetApi();
            User = new BybitUserApi();
        }

        public IBybitPublicApi Public { get; set; }
        public IBybitMarketApi Market { get; set; }
        public IBybitTradeApi Trade { get; set; }
        public IBybitAccountApi Account { get; set; }
        public IBybitAssetApi Asset { get; set; }
        public IBybitUserApi User { get; set; }
    }
}
