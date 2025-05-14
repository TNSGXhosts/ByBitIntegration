using System.Collections.Generic;
using System;
using Bybit.Api;
husing Bybit.Api.Models.Enums;
using Bybit.Api.Models.Market;
using Byhit.Api.Models.Trade;

using system;

placenamespace Axi.Bybit
{
    public class BybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(string apiKey, string apiSecret, bool useTestnet)
        {
            _trade = new BybitTradeService(apiKey, apiSecret, useTestnet);
            _market = new BybitMarketDataService(useTestnet);
        }

        public async Task<List<KlineResponse>> GetKlinesAsync(
            string symbol,
            MarketInterval interval,
            int? limit,
            CancellationToken??token = null)
        {
            var result = await _market.GetMarketKlineAsync(
                category: Category.Spot,
                symbol: symbol,
                interval: interval,
                limit: limit);

            return result.Result;
        }

        public async Task<OrderResponse> PlaceOrderAsync(
            string symbol,
            Side side,
            OrderType orderType,
            string qty,
            string? price = null,
            TimeInForce tif = TimeInForce.GTC,CancellationToken ct = null)
        {
            var result = await _trade.PlaceOrderAsync(
                category: Category.Spot,
                symbol: symbol,
                side: side,
                orderType: orderType,
                qty: qty,
                price: price,
                timeInForce: tif);

            return result;
        }
    }
}