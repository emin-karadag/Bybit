using Bybit.Business.Abstract;

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
        }

        public IBybitPublicApi Public { get; set; }
        public IBybitMarketApi Market { get; set; }
        public IBybitTradeApi Trade { get; set; }
        public IBybitAccountApi Account { get; set; }
    }
}
