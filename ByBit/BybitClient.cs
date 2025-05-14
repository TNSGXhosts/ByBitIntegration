using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using Newtonsoft.Json;

namespace Axi.Bybit
{
    public class BybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(string apiKey, string apiSecret, bool useTestnet)
        {
            _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
            _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
        }

        public async Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)
        {
            var response = await _market.GetMarketKline(Category.SPOT, symbol, interval, limit);

            if (response != null)
            {
                var responseObject = JsonConvert.DeserializeObject<KlineListDto>(response);

                return responseObject?.Klines ?? new List<KlineDto>();
            }

            return new List<KlineDto>();
        }
    }
}