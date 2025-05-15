using bybit.net.api.Models.Market;
using bybit.net.api.Models.Trade;
using MyProject.Domain.BybitModels.Prices;
using MyProject.Domain.BybitModels.Trading;
using MyProject.Domain.BybitModels.Account;

namespace Bybit.BybitClient
{
    public interface IBybitClient
    {
        Task<List<Kline>> GetKlinesAsync(string symbol, MarketInterval interval, int? limit = null);
        Task<PlaceOrderResult> PlaceOrderAsync(string symbol, Side side, OrderType orderType, decimal qty);
        Task<WalletBalance?> GetWalletBalanceAsync(string accountType);
    }
}
