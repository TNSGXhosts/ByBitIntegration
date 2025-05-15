
using bybit.net.api.Account;
using MyProject.Domain.BybitModels.Account;

namespace Bybit.BybitClient
{
    public partial class BybitClient : IBybitClient
    {
        public async Task<WalletBalance?> GetWalletBalanceAsync(string accountType)
        {
            var accountService = new BybitAccountService(
                _trade.Credentials.Key,
                _trade.Credentials.Secret,
                debugMode: _trade.DebugMode
            );

            var response = await accountService.GetWalletBalanceAsync(accountType);

            if (!string.IsNullOrEmpty(response))
            {
                var parsed = JsonConvert.DeserializeObject<WalletBalance>(response);
                return parsed;
            }

            return null;
        }
    }
}