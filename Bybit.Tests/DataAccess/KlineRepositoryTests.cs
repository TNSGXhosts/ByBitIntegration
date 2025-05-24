using Microsoft.EntityFrameworkCore;
using ByBit.DataAccess;
using ByBit.DataAccess.Entities;
using ByBit.DataAccess.Repositories;
using NUnit.Framework;

namespace ByBit.Tests.DataAccess;

[TestFixture]
public class KlineRepositoryTests
{
    private KlineDbContext _context = null!;
    private KlineRepository _repository = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<KlineDbContext>()
            .UseInMemoryDatabase("klines")
            .Options;
        _context = new KlineDbContext(options);
        _repository = new KlineRepository(_context);
    }

    [Test]
    public async Task SaveAsync_SavesRecords()
    {
        var klines = new[]
        {
            new KlineEntity { Symbol = "BTCUSDT", Interval = Interval.One, StartTime = 1, Open = 1, High = 1, Low = 1, Close = 1, Volume = 1, Turnover = 1 },
        };

        await _repository.SaveAsync(klines);

        var saved = await _repository.GetAsync("BTCUSDT", Interval.One);
        Assert.That(saved, Has.Count.EqualTo(1));
    }
}
