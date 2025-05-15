
using System.Collections.Generic;

namespace MyProject.Domain.BybitModels
{
    public class WalletBalanceResponse
    {
        public string? TotalEquity { get; set; }
        public string? AccountIMRate { get; set; }
        public string? TotalMarginBalance { get; set; }
        public string? TotalInitialMargin { get; set; }
        public string? AccountType { get; set; }
        public string? TotalAvailableBalance { get; set; }
        public string? AccountMMRate { get; set; }
        public string? TotalPerpUPL { get; set; }
        public string? TotalWalletBalance { get; set; }
        public string? AccountLTV { get; set; }
        public string? TotalMaintenanceMargin { get; set; }
        public List<CoinBalance> Coin { get; set; }
    }

    public class CoinBalance
    {
        public string? AvailableToBorrow { get; set; }
        public string? Bonus { get; set; }
        public string? AccruedInterest { get; set; }
        public string? AvailableToWithdraw
        { get; set; }
        public string? TotalOrderIM { get; set; }
        public string? Equity { get; set; }
        public string? TotalPositionMM { get; set; }
        public string? UsdValue { get; set; }
        public string? SpotHedgingQty { get; set; }
        public string? UnrealisedPnl { get; set; }
        public bool CollateralSwitch { get; set; }
        public string? BorrowAmount { get; set; }
        public string? TotalPositionIM { get; set; }
        public string? WalletBalance { get; set; }
        public string? CumRealisedPnl { get; set; }
        public string? Locked { get; set; }
        public bool MarginCollateral { get; set; }
        public string? Coin { get; set; }
    }
}