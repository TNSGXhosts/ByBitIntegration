namespace MyProject.Domain.BybitModels;
public class WalletBalanceResponse
{
    public int RetCode { get; set; }
    public required string RetMsg { get; set; }
    public required Result Result { get; set; }
}

public class Result
{
    public required IEnumerable<WalletBalance> List { get; set; }
}

public class WalletBalance
{
    public decimal TotalEquity { get; set; }
    public decimal AccountIMRate { get; set; }
    public decimal TotalMarginBalance { get; set; }
    public decimal TotalInitialMargin { get; set; }
    public required string AccountType { get; set; }
    public decimal TotalAvailableBalance { get; set; }
    public decimal AccountMMRate { get; set; }
    public decimal TotalPerpUPL { get; set; }
    public decimal TotalWalletBalance { get; set; }
    public decimal AccountLTV { get; set; }
    public decimal TotalMaintenanceMargin { get; set; }
    public required IEnumerable<Coin> Coin { get; set; }
}

public class Coin
{
    public decimal AvailableToBorrow { get; set; }
    public decimal Bonus { get; set; }
    public decimal AccruedInterest { get; set; }
    public decimal AvailableToWithdraw { get; set; }
    public decimal TotalOrderIM { get; set; }
    public decimal Equity { get; set; }
    public decimal TotalPositionMM { get; set; }
    public decimal UsdValue { get; set; }
    public decimal SpotHedgingQty { get; set; }
    public decimal UnrealisedPnl { get; set; }
    public bool CollateralSwitch { get; set; }
    public decimal BorrowAmount { get; set; }
    public decimal TotalPositionIM { get; set; }
    public decimal WalletBalance { get; set; }
    public decimal CumRealisedPnl { get; set; }
    public decimal Locked { get; set; }
    public bool MarginCollateral { get; set; }
    public required string CoinName { get; set; }
}