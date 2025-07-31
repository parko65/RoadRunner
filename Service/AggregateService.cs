using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class AggregateService : IAggregateService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public AggregateService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AggregateDto>> GetAggregatesAsync(bool trackChanges)
    {
        var aggregates = await _repository.Aggregate.GetAggregatesAsync(trackChanges);

        var aggregateDtos = _mapper.Map<IEnumerable<AggregateDto>>(aggregates);

        return aggregateDtos;
    }

    public async Task<AggregateDto> GetAggregateAsync(int id, bool trackChanges)
    {
        var aggregate = await _repository.Aggregate.GetAggregateAsync(id, trackChanges);
        if (aggregate is null)
            throw new AggregateNotFoundException(id);

        var aggregateDto = _mapper.Map<AggregateDto>(aggregate);

        return aggregateDto;
    }

    public async Task<AggregateDto> CreateAggregateAsync(AggregateForCreationDto aggregateForCreation)
    {
        var aggregate = _mapper.Map<Aggregate>(aggregateForCreation);

        _repository.Aggregate.CreateAggregate(aggregate);
        await _repository.SaveAsync();

        var aggregateToReturn = _mapper.Map<AggregateDto>(aggregate);

        return aggregateToReturn;
    }

    public async Task DeleteAggregateAsync(int id, bool trackChanges)
    {
        var aggregate = await _repository.Aggregate.GetAggregateAsync(id, trackChanges);
        if (aggregate is null)
            throw new AggregateNotFoundException(id);

        _repository.Aggregate.DeleteAggregate(aggregate);

        await _repository.SaveAsync();
    }
}
