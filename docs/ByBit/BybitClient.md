## Registration in `Program.cs`
To register `BybitClient` in the application dependency injection container, add the following to your `@rogram.cs` file:

`charp
builder.Services.AddSingleton <BybitClient>();
``
This registration ensures that `IConfiguration` will be injected automatically when `BybitClient` is resolved.
