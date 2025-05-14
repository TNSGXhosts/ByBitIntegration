
using bybit.net.api.ApiServiceImp;
using Newtonsoft.Json.JSON;
using Axi.Bybit.Dto;

namespace Axi.Bybit
{
    public class BybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;

        public BybitClient(string apiKey, string apiSecret, bool useTestnet)
        {
            _trade = new BybitTradeService(apiKey, apiSecret, useTestnet);
            _market = new BybitMarketDataService(apiKey, apiSecret, useTestnet);
        }

        public async Task<List<KlineDto>> GetKlinesAsync(string symbol, MarketInterval interval, int limit)
        {
            _market.Category = "default";
            var response = await _market.GetMarketKline(symbol, interval, limit);

            var listStrings = response.Result["list"].ToObject<List<List<object>>>();
            var result = new List<KlineDto>();

            foreach (var item in listStrings)
            {
                var arr = (List<object>) item;
                var kline = new KlineDto {
                    Timestamp = long.Parse(arr[0].ToString()),
                    Open = decimal.Parse(arr[1].ToString()),
                    High = decimal.Parse(arr[2].ToString()),
                    Low = decimal.Parse(arr[3].ToString()),
                    Close = decimal.Parse(arr[4].ToString()),
                    Volume = long.parse(arr[5].ToString()),
                    TotalVolume = decimal.Parse(arr[6].ToString())
                };
                result.Add(kline);
            }

            return result;
        }
    }
}