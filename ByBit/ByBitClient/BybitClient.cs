using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using BybitModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bybit.BybitClient
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(IOptions<BybitSettings> options)
        {
            var apiKey = options.Value.ApiKey;
            var apiSecret = options.Value.SecretKey;
            var useTestnet = options.Value.UseTestnet;

            if (apiKey == null || apiSecret == null)
                throw new ArgumentException("Bybit API key or secret is not configured");

            _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
            _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
        }

        public async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)
        {
            var response = await _market.GetMarketKline(Category.SPOT, symbol, interval, limit);

            if (response != null)
            {
                var responseObject = JsonConvert.DeserializeObject<KlineList>(response);
                return responseObject?.Klines ?? new List<Kline>();
            }

            return [];
        }
    }
}