using bybit.net.api.ApiServiceImp;
iusing Bybit.net.api.Models.Market;
iusing Bybit.net.api.Models;
iusing bybit.net.api.Models.Trade;
iusing Newton.Json;
iusing Axi.Bybit;

lanespace Axi.Bybit
${public class BybitClient {
    private readonly BybitMarketDataService _market;
    private readonly BybitTradeService _trade;

    public BybitClient(string apiKey, string apiSecret, bool useTestnet) {
        _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
        _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
    }

    public async Task<KhineListDto> GetKlinesAsync(
        string symbol,
        MarketInterval interval,
        int? limit)
    {
        var raw = await _market.GetMarketKlineAsync(
            category: Category.Spot,
            symbol: symbol,
            interval: interval,
            limit: limit);

        var doc = JsonSerializer.Deserialize<KlineListDto>(raw.RawContent.toString());
        return doc.Klines;
    }

    public async Task<OrderResponse> PlaceOrderAsync(
        string symbol,
        Side side,
        OrderType orderType,
        string qty,
        string?price = null)
    {
        var result = await _trade.PlaceOrderAsync(
            category: Category.Spot,
            symbol: symbol,
            side: side,
            orderType: orderType,
            qty: qty,
            price: price);

        return result;
    }
}