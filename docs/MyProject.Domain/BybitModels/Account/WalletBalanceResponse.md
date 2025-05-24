# WalletBalanceResponse

Represents the structure returned by the `v5/account/wallet-balance` endpoint. The model contains the high level fields as well as nested `Coin` information.

Only the most relevant properties are mapped in this project.

```json
{
  "retCode": 0,
  "retMsg": "OK",
  "result": {
    "list": [ { "accountType": "UNIFIED", "totalEquity": 100.0, ... } ]
  }
}
```
