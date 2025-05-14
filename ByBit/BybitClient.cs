using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using Newtonsoft.Json;

namespace Bybit
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(IConfiguration configuration)
        {
            var apiKey = configuration["BYBIT_API_KEY"];
            var apiSecret = configuration["BYBIT_API_SECRET"];
            var useTestnet = configuration.GetValue<bool>("BYBIT_USE_TESNET");

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