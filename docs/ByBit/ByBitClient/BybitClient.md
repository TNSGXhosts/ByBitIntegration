# BybitClient.cs

##  🐳 Initial Requirements

- Realizuet .NET cliient desascirovannen to REST API Bybit
- Inkapsuliruet rabotu s rynocknoy servisami:
    - _market
    - _trade
- Initializiruet nastroki cherez DI
- Obrésh konfiguratsio� api Predostavlyaet metod `GetKlinesAsync` dlya zopasa spisk svechey na zadanny ----

## 🌍 Technical Implementation
## 🐻 Spaces namen
``c
using [Bybit.BybitClient];
```

## 🔳 Konstruktor

```public BybitClient(IOptions<[BybitSettings]> options)````

* Ispoltujet token @IOptions structura
* Validiruet parametry, wybirazaet isklyushenie K*
* Initializuet 2 vnutrennego clients:
  * @bybitMarketDataService
  * @bybitTradeService

## 📳 Method: @GetKlinesAsync

```public async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)```

* Dealazh call @taskault GetMarketKline
* Ipplies API properties from `_market`
* Deserializacia tylem: `JSON.Convert:DeserializeObject`
* Vozvarats list objectov `Kline`, liboms `List<kline>`

- Task using any neuetrallie arguments vez pruzh.

