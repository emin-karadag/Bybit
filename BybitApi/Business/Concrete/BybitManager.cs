using Bybit.Business.Abstract;
using BybitApi.Business.Abstract;
using BybitApi.Business.Concrete;

namespace Bybit.Business.Concrete
{
    public class BybitManager : IBybitService
    {
        public BybitManager()
        {
            Public = new BybitPublicApi();
            Market = new BybitMarketApi();
            Trade = new BybitTradeApi();
            Position = new BybitPositionApi();
            Account = new BybitAccountApi();
            Asset = new BybitAssetApi();
            User = new BybitUserApi();
        }

        public IBybitPublicApi Public { get; set; }
        public IBybitMarketApi Market { get; set; }
        public IBybitTradeApi Trade { get; set; }
        public IBybitPositionApi Position { get; set; }
        public IBybitAccountApi Account { get; set; }
        public IBybitAssetApi Asset { get; set; }
        public IBybitUserApi User { get; set; }
    }
}
