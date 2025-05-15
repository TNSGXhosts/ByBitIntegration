# BybitIntegrationRegistry

Class used to register client and configuration from `AppSettings`.


### Public method:

__RegisterBybitIntegrationServices__

REGISTER client and settings.

Usage:

```c
services.RegisterBybitIntegrationServices(configuration);
```

### Private static configuration method:

Extracts `BybitSettings` from configuration tree.

Data is bound to the `BybitSettings` class and bind via:
```cs
services.Configure<BybitSettings>(settings =>
  configuration.GetSection(nameof(BybitSettings)).Bind(settings));
```


The service is instantiated as a singleton for simple disposable actions.
