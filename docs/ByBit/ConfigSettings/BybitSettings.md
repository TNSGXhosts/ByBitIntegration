# BybitSettings

### Class description

@class: BybitSettings
@description: Configuration class used to bind via `appsettings.json` and resolved through IOptions.

Contains three fields:

 - `ApiKey`: required string
 - `SecretKey`: required string
 - `UseTestnet`: boolean value to specify whether to use the testnet
### Usage

```cs
services.AddBybitTradingClient(o => {
  o.ApiKey = Environment.GetEnvironmentVariable("BYBIT_API_KEY");
  o.ApiSecret = Environment.GetEnvironmentVariable("BYBIT_API_SECRET");
  o.UseTestnet = true;
});
```
