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

namespace Bybit.BybitClient
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;
        private readonly BybitAccountService _account;

        public BybitClient(IOptions<BybitSettings> options)
        {
            var apiKey = options.Value.ApiKey;
            var apiSecret = options.Value.SecretKey;
            var useTestnet = options.Value.UseTestnet;

            if (apiKey == null || apiSecret == null)
                throw new ArgumentException("Bybit API key or secret is not configured");
            _trade = new BybitTradeService(apiKey, apiSecret, debugMode: useTestnet);
            _market = new BybitMarketDataService("https://api-testnet.bybit.com", debugMode: useTestnet);
            _account = new BybitAccountService(apiKey, apiSecret, debugMode: useTestnet);
        }

        public async Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null)
        {
            var response = await _market.GetMarketKline(Category.INVERSE, symbol, interval, limit: limit);
            if (!string.IsNullOrEmpty(response))
            {
                var responseModel = JsonConvert.DeserializeObject<KlineResponse>(response);
                return responseModel?.Result?.Klines ?? [];
            }

            return [];
        }

        public async Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty)
        {
            var response = await _trade.PlaceOrder(Category.SPOT, symbol, side, orderType, qty.ToString());
            if (!string.IsNullOrEmpty(response))
            {
                var responseModel = JsonConvert.DeserializeObject<PlaceOrderResult>(response);
                return responseModel ?? new PlaceOrderResult() { OrderId = string.Empty, OrderLinkId = string.Empty };
            }

            return new PlaceOrderResult() { OrderId = string.Empty, OrderLinkId = string.Empty };
        }

        public async Task<WalletBalanceResponse?> GetWalletBalanceAsync(AccountType accountType)
        {
            return await _account.GetAccountBalance(accountType);
        }
    }
}