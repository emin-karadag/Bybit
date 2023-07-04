using BybitApi.Business.Abstract;

namespace Bybit.Business.Abstract
{
    public interface IBybitService
    {
        public IBybitPublicApi Public { get; set; }
        public IBybitMarketApi Market { get; set; }
        public IBybitTradeApi Trade { get; set; }
        public IBybitPositionApi Position { get; set; }
        public IBybitAccountApi Account { get; set; }
        public IBybitAssetApi Asset { get; set; }
        public IBybitUserApi User { get; set; }
    }
}
