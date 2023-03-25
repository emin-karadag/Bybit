using Bybit.Business.Abstract;

namespace Bybit.Business.Concrete
{
    public class BybitManager : IBybitService
    {
        public BybitManager()
        {
            Market = new BybitMarketApi();
            //Order = new BybitOrderApi();
            //Position = new BybitPositionApi();
            //Account = new BybitAccountApi();
            //Asset = new BybitAssetApi();
            //SpotLeverageToken = new BybitSpotLeverageTokenApi();
            //SpotMarginTrade = new BybitSpotMarginTradeApi();
        }

        public IBybitMarketApi Market { get; set; }
        //public IBybitOrderApi Order { get; set; }
        //public IBybitPositionApi Position { get; set; }
        //public IBybitAccountApi Account { get; set; }
        //public IBybitAssetApi Asset { get; set; }
        //public IBybitSpotLeverageTokenApi SpotLeverageToken { get; set; }
        //public IBybitSpotMarginTradeApi SpotMarginTrade { get; set; }
    }
}
