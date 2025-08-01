using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class BitumenRepository : RepositoryBase<Bitumen>, IBitumenRepository
{
    public BitumenRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Bitumen>> GetBitumensAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(b => b.MaterialNumber)
            .ToListAsync();

    public async Task<Bitumen?> GetBitumenAsync(int id, bool trackChanges) =>
        await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    public void CreateBitumen(Bitumen bitumen) => Create(bitumen);

    public void DeleteBitumen(Bitumen bitumen) => Delete(bitumen);
}
