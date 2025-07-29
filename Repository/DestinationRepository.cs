using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
{
    public DestinationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<Destination>> GetDestinationsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(d => d.Id)
            .ToListAsync();
    }
    public async Task<Destination?> GetDestinationAsync(int id, bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }
    public void CreateDestination(Destination destination) => Create(destination);
}
