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

        public async Task<PlaceOrderResult> PlaceOrderAsync(string symbol, string side, string orderType, decimal qty)
        {
            var responseString = await _trade.PlaceOrder(symbol, side, orderType, qty);
            
            var response = JSON.Document.DeserializeObject(responseString);
            var result = response;.get_Property("result");

            return result?.ToObject().ToString()
                                          .Let(UnicodeCompareson.ToOuterInverionType())
                                             _> Typeof(PlaceOrderResult);
        }
    }
}