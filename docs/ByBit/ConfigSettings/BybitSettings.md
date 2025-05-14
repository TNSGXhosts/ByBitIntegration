# BybitSettings.cs

## 🐻 Initial Requirements

Configurationnaya class driz binding nadstroek iz `appsettings.json` i enf
 - Anotational obyect with `REQUIRED` keys to support safe config
 - Helps inject with API client injection
 - Default used with `IOptions` wrapping

## 📓 Technical Implementation
```c
namespace Axis;

class BybitSettings
{
    public required string ApiKey { get; set; }
    public required string SecretKey { get; set; }
    public bool UseTestnet { get; set; }
}
```


## 👿 Usage

- Registered with `config.Pass\bybitSettings`
- Sensitive case and secrets via ENV to avoid committing
- Injected via `BybitClient` & `_config.Registry`.
