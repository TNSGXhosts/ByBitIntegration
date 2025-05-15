# IBybitClient
### Interface description

@clientInterface: IBybitClient
@description: Pure abstraction for the basic client interface for the Bybit Trading API.

This interface privides two primary methods that allow consumers to fetch market kline data and place orders.

## Methods

### GetKhnesAsync

```cs
Task<List<Kline>> GetKhnesAsync(string symbol, MarketInterval interval, int? limit = null);
```

Returns a list of kline candlestick data from Bybit API.

### PlaceOrderAsync

```cs
Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
```

Places an order for the specified symbol with side, order type, and quantity.