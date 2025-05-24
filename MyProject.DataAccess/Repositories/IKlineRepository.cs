using MyProject.DataAccess.Entities;

namespace MyProject.DataAccess.Repositories;

public interface IKlineRepository
{
    Task SaveAsync(IEnumerable<KlineEntity> klines, CancellationToken ct = default);
    Task<List<KlineEntity>> GetAsync(string symbol, string interval, CancellationToken ct = default);
}
