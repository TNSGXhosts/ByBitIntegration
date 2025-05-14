using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models.Market;
using bybit.net.api.Models;
using bybit.net.api.Models.Trade;

namespace Axi.Bybit
{
    public class BybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(string apiKey, string apiSecret, bool useTestnet)
        {
            _trade = new BybitTradeService(apiKey, apiSecret, debugMode:useTestnet);
            _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
        }

        public async Task<List<KlineResponse>> GetKlinesAsync(
            string symbol,
            MarketInterval interval,
            int? limit)
        {
            var result = await _market.GetMarketKline(
                category: Category.SPOT,
                symbol: symbol,
                interval: interval,
                limit: limit);

            return result;
        }

        public async Task<OrderResponse> PlaceOrderAsync(
            string symbol,
            Side side,
            OrderType orderType,
            string qty,
            string? price = null)
        {
            var result = await _trade.PlaceOrder(
                category: Category.SPOT,
                symbol: symbol,
                side: side,
                orderType: orderType,
                qty: qty,
                price: price);

            return result;
        }
    }
}