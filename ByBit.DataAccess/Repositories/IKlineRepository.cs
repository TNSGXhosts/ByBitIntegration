using ByBit.DataAccess.Entities;

namespace ByBit.DataAccess.Repositories;

public interface IKlineRepository
{
    Task SaveAsync(IEnumerable<KlineEntity> klines, CancellationToken ct = default);
    Task<List<KlineEntity>> GetAsync(string symbol, Interval interval, CancellationToken ct = default);
}
