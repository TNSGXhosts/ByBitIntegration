using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using bybit.net.api.Models.Account;
using BybitModels;
using Microsoft.Extensions.Options;
using MyProject.Domain.BybitModels.Prices;
using MyProject.Domain.BybitModels.Trading;
using Newtonsoft.Json;
using MyProject.Domain.BybitModels;

namespace Bybit.BybitClient
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;
        private readonly BybitAccountService _account;
        private const string Url = "https://api-testnet.bybit.com";

        public BybitClient(IOptions<BybitSettings> options)
        {
            var apiKey = options.Value.ApiKey;
            var apiSecret = options.Value.SecretKey;
            var useTestnet = options.Value.UseTestnet;

            if (apiKey == null || apiSecret == null)
                throw new ArgumentException("Bybit API key or secret is not configured");
            _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
            _market = new BybitMarketDataService(Url, debugMode: useTestnet);
            _account = new BybitAccountService(apiKey, apiSecret, url: Url, debugMode: useTestnet);
        }

        public async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null)
        {
            var response = await _market.GetMarketKline(Category.INVERSE, symbol, interval, limit: limit);
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Unable to get klines");
            }

            var responseModel = JsonConvert.DeserializeObject<KlineResponse>(response);
            return responseModel?.Result?.Klines ?? [];
        }

        public async Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty)
        {
            var response = await _trade.PlaceOrder(Category.SPOT, symbol, side, orderType, qty.ToString());
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Unable to place order");
            }

            var responseModel = JsonConvert.DeserializeObject<PlaceOrderResult>(response);
            return responseModel ?? new PlaceOrderResult() { OrderId = string.Empty, OrderLinkId = string.Empty };
        }

        public async Task<IEnumerable<WalletBalance>> GetWalletBalanceAsync(AccountType accountType)
        {
            var response = await _account.GetAccountBalance(accountType);
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Unable to get wallet balance");
            }

            var responseModel = JsonConvert.DeserializeObject<WalletBalanceResponse>(response);
            return responseModel?.Result?.List ?? [];
        }
    }
}