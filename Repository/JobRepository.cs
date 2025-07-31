using Contracts;
using Entities.Models;
using Enums;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class JobRepository : RepositoryBase<Job>, IJobRepository
{
    public JobRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Job>> GetJobsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(j => j.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Job>> GetJobsByStatusAsync(JobStatus status, bool trackChanges)
    {
        return await FindByCondition(j => j.Status.Equals(status), trackChanges)
            .Include(j => j.Recipe)
            .Include(j => j.Destination)
            .OrderBy(j => j.Id)
            .ToListAsync();
    }

    public async Task<Job?> GetJobAsync(int id, bool trackChanges)
    {
        return await FindByCondition(j => j.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateJob(Job job) => Create(job);
}