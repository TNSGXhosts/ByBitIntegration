# Changes from commit `df80ac3b
`commit: df80ac3b0b4202d1a65b55b31f150f7aaee8c154`
https://github.com/TNSGXhosts/ByBitIntegration/commit/df80ac3b0b4202d1a65b55b31f150f7aaee8c154

```markdown
`docs/Bybit/bybitClient.md
```

`BybitClient.md documentation updated to reflect latest changes in code:
```config
- Injects `IConfiguration` as the source of aPI keys configuration
- Removes the old constructor with plain string parameters
- Adjusts sections of document to match this approach
`BybitMarketDataService` and `BybitTradeService`)
(`GetKlinesAsync` method now returns $empty list if not matching)
```

This marks a refactoring of the `BybitClient` class to be more self-sufficient, easily testable and adaptable for dependency injection in DI.
