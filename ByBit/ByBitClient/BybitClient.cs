using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using bybit.net.api.Services.Account;
using BybitModels;
using Microsoft.Extensions.Options;
using MyProject.Domain.BybitModels.Prices;
using MyProject.Domain.BybitModels.Trading;
using MyProject.Domain.BybitModels.Account;
using Newtonsoft.Json;

namespace Bybit.BybitClient
{
    public class BybitClient : IBybitClient
    {
        private readonly BybitMarketDataService _market;
        private readonly BybitTradeService _trade;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly bool _useTestnet;

        public BybitClient(IOptions<BybitSettings> options)
        {
            _apiKey = options.Value.ApiKey;
            _apiSecret = options.Value.SecretKey;
            _useTestnet = options.Value.UseTestnet;
            _trade = new BybitTradeService(_apiKey, _apiSecret, debugMode: _useTestnet);
            _market = new BybitMarketDataService("https://api-testnet.bybit.com", debugMode: _useTestnet);
        }

        public async Task<WalletBalance?> GetWalletBalanceAsync(string accountType)
        {
            var accountService = new BybitAccountService(_apiKey, _apiSecret);
            var response = await accountService.GetWalletBalanceAsync(accountType);
            return response;
        }
    }
}