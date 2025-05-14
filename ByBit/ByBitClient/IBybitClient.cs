using bybit.net.api.Models.Market;

namespace Bybit;

public interface IBybitClient
{
    Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit);
}