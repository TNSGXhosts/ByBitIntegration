using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using bybit.net.api.ApiServiceImp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace AlgoTrading.Bybit;

public record KlineRecord(
    DateTimeOffset OpenTime,
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    decimal Volume,
    decimal Turnover);

public record OrderResponse(string OrderId, string? OrderLinkId);

public record BybitSettings(string ApiKey, string ApiSecret, bool UseTestnet = false);

public interface IBybitTradingClient
{
    Task<IReadOnlyList<KlineRecord>> GetKlinesAsync(
        string symbol,
        MarketInterval interval,
        int? limit = null,
        CancellationToken cancellationToken = default);

    Task<OrderResponse> PlaceOrderAsync(
        string symbol,
        Side side,
        OrderType orderType,
        string qty,
        string? price = null,
        TimeInForce tif = TimeInForce.GTC,
        CancellationToken cancellationToken = default);
}

internal sealed class BybitTradingClient : IBybitTradingClient
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
    };

    private readonly BybitMarketDataService _market;
    private readonly BybitTradeService _trade;

    public BybitTradingClient(IOptions<BybitSettings> options)
    {
        var cfg = options.Value;
        _market = new BybitMarketDataService(cfg.UseTestnet);
        _trade = new BybitTradeService(cfg.ApiKey, cfg.ApiSecret, cfg.UseTestnet);
    }

    public async Task<IReadOnlyList<KlineRecord>> GetKlinesAsync(
        string symbol,
        MarketInterval interval,
        int? limit = null,
        CancellationToken cancellationToken = default)
    {
        var rawJson = await _market.GetMarketKline(
            Category.SPOT, symbol, interval, limit: limit ?? 200) ?? string.Empty;

        using var doc = JsonDocument.Parse(rawJson);
        if (!doc.RootElement.TryGetProperty("result", out var result) ||
            !result.TryGetProperty("list", out var listNode))
        {
            return Array.Empty<KlineRecord>();
        }

        var records = new List<KlineRecord>(listNode.GetArrayLength());
        foreach (var el in listNode.EnumerateArray())
        {
            var arr = el.EnumerateArray().ToArray();
            if (arr.Length < 7) continue;

            var ts = DateTimeOffset.FromUnixTimeSeconds(long.Parse(arr[0].GetString()!));
            static decimal D(JsonElement x) => decimal.Parse(x.GetString()!, CultureInfo.InvariantCulture);
            records.Add(new KlineRecord(ts, D(arr[1]), D(arr[2]), D(arr[3]), D(arr[4]), D(arr[5]), D(arr[6])));
        }

        return records;
    }

    public async Task<OrderResponse> PlaceOrderAsync(
        string symbol,
        Side side,
        OrderType orderType,
        string qty,
        string? price = null,
        TimeInForce tif = TimeInForce.GTC,
        CancellationToken cancellationToken = default)
    {
        var rawJson = await _trade.PlaceOrder(
            category: Category.LINEAR,
            symbol: symbol,
            side: side,
            orderType: orderType,
            qty: qty,
            price: price,
            timeInForce: tif) ?? string.Empty;

        using var doc = JsonDocument.Parse(rawJson);
        if (!doc.RootElement.TryGetProperty("result", out var result))
        {
            throw new InvalidOperationException("Missing result in PlaceOrder response");
        }

        var orderId = result.GetProperty("orderId").GetString() ?? string.Empty;
        var orderLinkId = result.TryGetProperty("orderLinkId", out var ol) ? ol.GetString() : null;

        return new OrderResponse(orderId, orderLinkId);
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBybitTradingClient(
        this IServiceCollection services,
        Action<BybitSettings> configure)
    {
        services.Configure(configure);
        services.AddSingleton<IBybitTradingClient, BybitTradingClient>();
        return services;
    }
}


// -----------------------------------------------------------------------------
//  Пример использования
// -----------------------------------------------------------------------------
//
// services.AddBybitTradingClient(o =>
// {
//     o.ApiKey    = Environment.GetEnvironmentVariable("BYBIT_API_KEY")!;
//     o.ApiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET")!;
//     o.UseTestnet = true; // или false – для боевой торговли
// });
//
// var client = sp.GetRequiredService<IBybitTradingClient>();
//
// // Получить свечи
// var klines = await client.GetKlinesAsync("BTCUSDT", MarketInterval.OneMinute);
//
// // Разместить рыночный ордер
// await client.PlaceOrderAsync("BTCUSDT", Side.BUY, OrderType.MARKET, qty: "0.001");
