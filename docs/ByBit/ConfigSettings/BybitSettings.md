# BybitSettings

Configuration options used by `BybitClient`. The values are typically loaded from `appsettings.json` and bound via `IOptions<T>`.

| Property   | Description                              |
|------------|------------------------------------------|
| `ApiKey`   | Your Bybit API key.                      |
| `SecretKey`| Your Bybit API secret.                   |
| `UseTestnet` | When `true`, requests are sent to `https://api-testnet.bybit.com`. |

Example `appsettings.json` section:
```json
{
  "BybitSettings": {
    "ApiKey": "<your key>",
    "SecretKey": "<your secret>",
    "UseTestnet": true
  }
}
```
