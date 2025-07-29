using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class DestinationService : IDestinationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public DestinationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DestinationDto>> GetDestinationsAsync(bool trackChanges)
    {
        var destinations = await _repository.Destination.GetDestinationsAsync(trackChanges);

        var destinationsDto = _mapper.Map<IEnumerable<DestinationDto>>(destinations);

        return destinationsDto;
    }

    public async Task<DestinationDto> GetDestinationAsync(int id, bool trackChanges)
    {
        var destination = await _repository.Destination.GetDestinationAsync(id, trackChanges);
        if (destination is null)
            throw new DestinationNotFoundException(id);

        var destinationDto = _mapper.Map<DestinationDto>(destination);

        return destinationDto;
    }

    public async Task<DestinationDto> CreateDestinationAsync(DestinationForCreationDto destinationForCreation)
    {
        var destinationEntity = _mapper.Map<Destination>(destinationForCreation);

        _repository.Destination.CreateDestination(destinationEntity);
        await _repository.SaveAsync();

        var destinationToReturn = _mapper.Map<DestinationDto>(destinationEntity);

        return destinationToReturn;
    }
}
