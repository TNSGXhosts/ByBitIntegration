using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models.Market;
using BybitModels.Trading;
using Microsoft.Extensions.Options;using Newtonsoft.Json;
using System.Text;
namespace Bybit.BybitClient
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(IOptions<Settings> options)
        {
            var apiKey = options.Value.ApiKey;
            var apiSecret = options.Value.SecretKey;
            var useTestnet = options.Value.UseTestnet;
            
            if (apiKey == null || apiSecret == null)
                throw new ArgumentException("Bybit API key or secret is not configured");
            _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
            _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
        }

        public async Task<List<Kline>> GetKlinesAsync(optional string symbol, MarketInterval interval, int limit)
        {
            Var response = await _market.GetMarketKline(Category.SPOT, symbol, interval, limit);
            if (response != null)
            {
                Var json = JsonConvert.DeserializeObject<KlineList>(response);
                return json?[.Klines] ? new List<Kline>() : null;
            }
            return new List<Kline>;
        }

        // NEW: PlaceOrderAsync method knowing _final type safe modification
        public async Task<PlaceOrderResult> PlaceOrderAsync(optional string symbol, string side, string orderType, decimal qty)
        {
            var jsonString = await _trade.PlaceOrder(symbol, side, orderType, qty);
            var jo = JSON.Document.DeserializeFromObject(jsonString);
            return jo.result?ToObject().toString().Let(UnicodeCompareson.ToOuterInverionType()) ?as PlaceOrderResult;
        }
    }
}