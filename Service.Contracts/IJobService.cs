using Enums;
using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IJobService
{
    Task<IEnumerable<JobDto>> GetJobsAsync(bool trackChanges);
    Task<IEnumerable<JobDto>> GetJobsByStatusAsync(JobStatus status, bool trackChanges);
    Task<JobDto?> GetJobAsync(int jobId, bool trackChanges);
    Task<JobDto> CreateJobAsync(JobForCreationDto jobForCreation);
}
