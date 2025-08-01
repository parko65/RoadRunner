using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IBitumenService
{
    Task<BitumenDto> GetBitumenAsync(int id, bool trackChanges);
    Task<IEnumerable<BitumenDto>> GetBitumensAsync(bool trackChanges);
    Task<BitumenDto> CreateBitumenAsync(BitumenForCreationDto bitumenForCreation);
    Task DeleteBitumenAsync(int id, bool trackChanges);
}