using Entities.Models;

namespace Contracts;
public interface IDestinationRepository
{
    Task<IEnumerable<Destination>> GetDestinationsAsync(bool trackChanges);
    Task<Destination?> GetDestinationAsync(int id, bool trackChanges);
    void CreateDestination(Destination destination);
}
