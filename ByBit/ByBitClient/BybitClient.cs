using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models;
using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
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
        private string _apiKey;
        private string _apiSecret;
        private bool _useTestnet;

        public BybitClient(IOptions<BybitSettings> options)
        {
            _apiKey = options.Value.ApiKey;
            _apiSecret = options.Value.SecretKey;
            _useTestnet = options.Value.UseTestnet;
            if (_apiKey == null || _apiSecret == null)
                throw new ArgumentException("Bybit API key or secret is not configured");
            _trade = new BybitTradeService(_apiKey, _apiSecret, debugMode: _useTestnet);
            _market = new BybitMarketDataService("https://api-testnet.bybit.com", debugMode: _useTestnet);
        }
        public async Task<WalletBalance?> GetWalletBalanceAsync(string accountType)
        {
            var accountService = new BybitAccountService(_apiKey, _apiSecret);
            var walletRes = await accountService.GetWalletBalanceAsync(accountType);
            return walletRes?.Data;
        }
    }
}