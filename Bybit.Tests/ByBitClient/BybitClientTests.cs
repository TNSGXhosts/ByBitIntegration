using bybit.net.api.Models.Market;
using Bybit;
using Bybit.BybitClient;
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
        var bybitSettings = new BybitSettings
        {
            ApiKey = "",
            SecretKey = "test-secret",
            UseTestnet = true
        };

        _optionsMock = new Mock<IOptions<BybitSettings>>();
        _optionsMock.Setup(o => o.Value).Returns(bybitSettings);

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
}