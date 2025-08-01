using Entities.Models;

namespace Contracts;
public interface IBitumenRepository
{
    Task<IEnumerable<Bitumen>> GetBitumensAsync(bool trackChanges);
    Task<Bitumen?> GetBitumenAsync(int id, bool trackChanges);
    void CreateBitumen(Bitumen bitumen);
    void DeleteBitumen(Bitumen bitumen);
}
