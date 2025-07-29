using Entities.Models;
using Enums;

namespace Contracts;
public interface IJobRepository
{
    Task<IEnumerable<Job>> GetJobsAsync(bool trackChanges);
    Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status, bool trackChanges);
    Task<Job?> GetJobAsync(int id, bool trackChanges);
    void CreateJob(Job job);
}
