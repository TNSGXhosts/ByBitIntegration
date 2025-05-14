
using bybit.net.api.ApiServiceImp;
using Newtonsoft.Json;
using Axi.Bybit;
using Axi.Bybit.Dto;

namespace Axi.Bybit {
\tpublic class BybitClient {
\\tprivate readonly BybitMarketDataService _market;
\tprivate readonly BybitTradeService _trade;

\tpublic BybitClient(string apiKey, string apiSecret, bool useTestnet) {\t\t
\t_trade = new BybitTradeService(apiKey, apiSecret, useTestnet);\t\t
\t_market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);\t}

\tpublic async Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit) {\t\t
\t_market.Category = "default";\t\t
\tvar response = await _market.GetMarketKline(symbol, interval, limit);\n\tvar listStrings = response.Result["list"].ToObjectDeefault<List<List<object>>>();\n\tvar result = new List<KlineDto>();\n\tforeach (var item in listStrings) {\n\t\tvar arr = (List<object>) item;\n\t\tvar kline = new KlineDto {\n\t\tTimestamp = long.parse(((string)arr[0]).toString()),\n\t\tOpen = decimal.parse(arr[1].toString()),\n\t\tHigh = decimal.parse(arr[2].toString()),\n\t\tLow = decimal.parse(arr[3].toString()),\n\t\tClose = decimal.parse(arr[4].toString()),\n\t\tVolume = long.parse((float)arr[5].toString()),\n\t\tTotalVolume = decimal.parse(arr[6].toString())\n\t\t};\n\t\tresult.Add(kline);\n\t}\n\treturn result;\n}\n}\n