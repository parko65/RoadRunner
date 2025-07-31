using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class AggregateRepository : RepositoryBase<Aggregate>, IAggregateRepository
{
    public AggregateRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Aggregate>> GetAggregatesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(a => a.MaterialNumber)
            .ToListAsync();

    public async Task<Aggregate?> GetAggregateAsync(int id, bool trackChanges) =>
        await FindByCondition(a => a.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateAggregate(Aggregate aggregate) => Create(aggregate);

    public void DeleteAggregate(Aggregate aggregate) => Delete(aggregate);
}
