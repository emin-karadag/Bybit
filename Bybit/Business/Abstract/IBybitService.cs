namespace Bybit.Business.Abstract
{
    public interface IBybitService
    {
        public IBybitPublicApi Public { get; set; }
        public IBybitMarketApi Market { get; set; }
        public IBybitTradeApi Trade { get; set; }
        public IBybitAccountApi Account { get; set; }
    }
}
