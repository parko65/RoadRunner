using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Enums;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class JobService : IJobService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public JobService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<JobDto>> GetJobsAsync(bool trackChanges)
    {
        var jobs = await _repository.Job.GetJobsAsync(trackChanges);

        var jobsDto = _mapper.Map<IEnumerable<JobDto>>(jobs);

        return jobsDto;
    }

    public async Task<IEnumerable<JobDto>> GetJobsByStatusAsync(JobStatus status, bool trackChanges)
    {
        var jobs = await _repository.Job.GetJobsByStatusAsync(status, trackChanges);

        var jobsDto = _mapper.Map<IEnumerable<JobDto>>(jobs);

        return jobsDto;
    }

    public async Task<JobDto?> GetJobAsync(int id, bool trackChanges)
    {
        var job = await _repository.Job.GetJobAsync(id, trackChanges);
        if (job is null)
            throw new JobNotFoundException(id);

        var jobDto = _mapper.Map<JobDto>(job);

        return jobDto;
    }

    public async Task<JobDto> CreateJobAsync(JobForCreationDto jobForCreation)
    {
        var job = _mapper.Map<Job>(jobForCreation);

        job.Status = JobStatus.Pending; // Default status
        job.Created = DateTime.Now; // Set creation time

        _repository.Job.CreateJob(job);
        await _repository.SaveAsync();

        var jobToReturn = _mapper.Map<JobDto>(job);

        return jobToReturn;
    }
}
