using bybit.net.api.Models.Account;
using bybit.net.api.Models.Market;
using Bybit;
using Bybit.BybitClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ByBit.Tests.ByBitClient;
[TestFixture]
public class BybitClientTests
{
    private Mock<IOptions<BybitSettings>> _optionsMock;
    private BybitClient _client;

    [SetUp]
    public void SetUp()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        var settings = configuration.GetSection(nameof(BybitSettings)).Get<BybitSettings>();

        _optionsMock = new Mock<IOptions<BybitSettings>>();
        _optionsMock.Setup(o => o.Value).Returns(settings);

        _client = new BybitClient(_optionsMock.Object);
    }

    [Test]
    public async Task GetKlinesAsync_ValidResponse_ReturnsKlines()
    {
        // Arrange
        var symbol = "BTCUSDT";
        var interval = MarketInterval.OneMinute;
        var limit = 1;

        // Act
        var result = await _client.GetKlinesAsync(symbol, interval, limit);

        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.GreaterThan(0));
        Assert.That(result[0].StartTime, Is.GreaterThan(0));
        Assert.That(result[0].Open, Is.GreaterThan(0));
        Assert.That(result[0].High, Is.GreaterThan(0));
        Assert.That(result[0].Low, Is.GreaterThan(0));
        Assert.That(result[0].Close, Is.GreaterThan(0));
        Assert.That(result[0].Volume, Is.GreaterThan(0));
        Assert.That(result[0].Turnover, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetWalletBalanceAsync_ValidResponse_ReturnsBalance()
    {

        // Act
        var result = await _client.GetWalletBalanceAsync(AccountType.Unified);

        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.GreaterThan(0));
        Assert.That(result.First().TotalEquity, Is.GreaterThan(0));
    }
}