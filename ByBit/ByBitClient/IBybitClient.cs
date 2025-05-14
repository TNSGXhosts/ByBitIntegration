using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using BybitModels;
using MyProject.Domain.BybitModels.Trading;

namespace Bybit.BybitClient;

public interface IBybitClient
{
    Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);
    Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
}
