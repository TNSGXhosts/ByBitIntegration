var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Axi.Bybit.BybitClient>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
