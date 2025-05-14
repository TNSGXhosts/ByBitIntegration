using bybit.net.api.Models.Market;
using BybitModels;

namespace Bybit.BybitClient;

public interface IBybitClient
{
    Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);
}