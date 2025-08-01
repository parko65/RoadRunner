using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class BitumenService : IBitumenService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BitumenService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BitumenDto>> GetBitumensAsync(bool trackChanges)
    {
        var bitumens = await _repository.Bitumen.GetBitumensAsync(trackChanges);

        var bitumenDtos = _mapper.Map<IEnumerable<BitumenDto>>(bitumens);

        return bitumenDtos;
    }

    public async Task<BitumenDto> GetBitumenAsync(int id, bool trackChanges)
    {
        var bitumen = await _repository.Bitumen.GetBitumenAsync(id, trackChanges);
        if (bitumen is null)
            throw new BitumenNotFoundException(id);

        var bitumenDto = _mapper.Map<BitumenDto>(bitumen);

        return bitumenDto;
    }

    public async Task<BitumenDto> CreateBitumenAsync(BitumenForCreationDto bitumenForCreation)
    {
        var bitumen = _mapper.Map<Bitumen>(bitumenForCreation);

        _repository.Bitumen.CreateBitumen(bitumen);
        await _repository.SaveAsync();

        var bitumenToReturn = _mapper.Map<BitumenDto>(bitumen);

        return bitumenToReturn;
    }

    public async Task DeleteBitumenAsync(int id, bool trackChanges)
    {
        var bitumen = await _repository.Bitumen.GetBitumenAsync(id, trackChanges);
        if (bitumen is null)
            throw new BitumenNotFoundException(id);

        _repository.Bitumen.DeleteBitumen(bitumen);

        await _repository.SaveAsync();
    }
}