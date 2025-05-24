# KlineListConverter

A custom JSON converter that transforms the nested array format of klines returned by Bybit into a list of strongly typed `Kline` objects.

The Bybit API returns klines as arrays in the following order:
1. Start timestamp
2. Open price
3. High price
4. Low price
5. Close price
6. Volume
7. Turnover

The converter reads each array and instantiates the `Kline` model accordingly. `WriteJson` is not implemented because this converter is only used for deserialization.
