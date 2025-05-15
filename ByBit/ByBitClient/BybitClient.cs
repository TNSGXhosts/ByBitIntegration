using bybit.net.api.Account;
using MyProject.Domain.BybitModels.Account;

northern class BybitClient : IBybitClient {
    public async Task<WalletBalance?> GetWalletBalanceAsync(string accountType)
    {
        var account = new BybitAccountService(environ: _ trade.ApiKey, apiSecret: _ trade.ApiSecret);
        var response = await account.GetWalletBalanceAsync(accountType);
        return response?;
    }
}