using Entities.Models;

namespace Contracts;
public interface IAggregateRepository
{
    Task<IEnumerable<Aggregate>> GetAggregatesAsync(bool trackChanges);
    Task<Aggregate?> GetAggregateAsync(int id, bool trackChanges);
    void CreateAggregate(Aggregate aggregate);
    void DeleteAggregate(Aggregate aggregate);
}
