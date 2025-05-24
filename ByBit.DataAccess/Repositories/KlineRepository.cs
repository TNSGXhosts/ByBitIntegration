using Microsoft.EntityFrameworkCore;
using ByBit.DataAccess.Entities;

namespace ByBit.DataAccess.Repositories;

public class KlineRepository : IKlineRepository
{
    private readonly KlineDbContext _context;

    public KlineRepository(KlineDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(IEnumerable<KlineEntity> klines, CancellationToken ct = default)
    {
        foreach (var kline in klines)
        {
            var exists = await _context.Klines.AnyAsync(k => k.Symbol == kline.Symbol &&
                                                           k.Interval == kline.Interval &&
                                                           k.StartTime == kline.StartTime, ct);
            if (!exists)
            {
                _context.Klines.Add(kline);
            }
        }

        await _context.SaveChangesAsync(ct);
    }

    public async Task<List<KlineEntity>> GetAsync(string symbol, Interval interval, CancellationToken ct = default)
    {
        return await _context.Klines
            .Where(k => k.Symbol == symbol && k.Interval == interval)
            .OrderBy(k => k.StartTime)
            .ToListAsync(ct);
    }
}
