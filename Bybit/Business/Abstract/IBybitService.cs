namespace Bybit.Business.Abstract
{
    public interface IBybitService
    {
        public IBybitMarketApi Market { get; set; }
        //public IBybitOrderApi Order { get; set; }
        //public IBybitPositionApi Position { get; set; }
        //public IBybitAccountApi Account { get; set; }
        //public IBybitAssetApi Asset { get; set; }
        //public IBybitSpotLeverageTokenApi SpotLeverageToken { get; set; }
        //public IBybitSpotMarginTradeApi SpotMarginTrade { get; set; }
    }
}
