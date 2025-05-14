using bybit.net.api.Models.Market;
using BybitModels;

namespace Bybit.BybicClient;

public interface IBybitClient
{
    Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);
    Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
}
