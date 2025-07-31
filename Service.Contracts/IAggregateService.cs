using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IAggregateService
{
    Task<AggregateDto> GetAggregateAsync(int id, bool trackChanges);
    Task<IEnumerable<AggregateDto>> GetAggregatesAsync(bool trackChanges);
    Task<AggregateDto> CreateAggregateAsync(AggregateForCreationDto aggregateForCreation);
    Task DeleteAggregateAsync(int id, bool trackChanges);
}