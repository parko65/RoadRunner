using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IRecipeRepository> _recipeRepository;
    private readonly Lazy<IJobRepository> _jobRepository;
    private readonly Lazy<IAggregateRepository> _aggregateRepository;
    private readonly Lazy<IDestinationRepository> _destinationRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _recipeRepository = new Lazy<IRecipeRepository>(() => new RecipeRepository(_repositoryContext));
        _jobRepository = new Lazy<IJobRepository>(() => new JobRepository(_repositoryContext));
        _aggregateRepository = new Lazy<IAggregateRepository>(() => new AggregateRepository(_repositoryContext));
        _destinationRepository = new Lazy<IDestinationRepository>(() => new DestinationRepository(_repositoryContext));
    }

    public IRecipeRepository Recipe => _recipeRepository.Value;
    public IJobRepository Job => _jobRepository.Value;
    public IAggregateRepository Aggregate => _aggregateRepository.Value;
    public IDestinationRepository Destination => _destinationRepository.Value;

    public async Task SaveAsync()
    {        
        await _repositoryContext.SaveChangesAsync();
    }
}
