# ByBit.DataAccess

This library contains the Entity Framework Core setup used to persist Bybit kline data.
It defines the `KlineDbContext`, entity models and a simple repository.

## Usage
1. Register `KlineDbContext` with your service container:
   ```csharp
   services.AddDbContext<KlineDbContext>(o => o.UseSqlite("Data Source=klines.db"));
   services.AddScoped<IKlineRepository, KlineRepository>();
   ```
2. Apply migrations and use `IKlineRepository` to store or query klines.

The context contains a single `Klines` table indexed by symbol, interval and start time. `Interval` is an enum with minute values (1, 3, 5, 15, 30, 60, 120, 240, 360, 720).
