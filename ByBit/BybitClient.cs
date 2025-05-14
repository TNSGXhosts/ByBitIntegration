using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using bybit.net.api.ApiServiceImp;
using System;

namespace Axi.Bybit;

public record OrderResponse(string OrderId, string? OrderLinkId);

public record bybitSettings(string apiKey, string apiSecret, bool useTestnet = false);

public interface IBybitTradingClient
{
    Task<List<KlineResponse>> GetKlinesAsync(
        string symbol,
        MarketInterval interval,
        int? limit = null,
        CancellationToken token = null);

    Task<OrderResponse> PlaceOrderAsync(
        string symbol,
        Side side,
        OrderType type,
        string qty,
        string? price,
        TimeInForce tif = TimeInForce.GTC,CancellationToken ct = null);
}

public class BybitClient : IBybitTradingClient
{
    private readonly BybitAccountService _account;
    private readonly BybitPositionService _position;

    public BybitClient(bybitSettings settings)
    {
        _account = new BybitAccountService(settings.apiKey, settings.apiSecret, settings.useTestnet);
        _position = new BybitPositionService(settings.apiKey, settings.apiSecret, settings.useTestnet);
    }

    public async Task<List<KlineResponse>> GetKlinesAsync(
        string symbol,
        MarketInterval interval,
        int? limit,
        CancellationToken token = null)
    {
        var response = await _account.GetKLines(symbol, interval, limit);
        return response.Result;
    }

    public async Task<OrderResponse> PlaceOrderAsync(
        string symbol,
        Side side,
        OrderType type,
        string qty,
        string?price,
        TimeInForce tif = TimeInForce.GTC,CancellationToken ct = null)
    {
        return await _position.PlaceOrder(symbol, side, type, qty, price, tif);
    }
}
