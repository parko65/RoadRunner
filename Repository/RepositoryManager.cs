using Contracts;

namespace Repository;
public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IRecipeRepository> _recipeRepository;
    private readonly Lazy<IJobRepository> _jobRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _recipeRepository = new Lazy<IRecipeRepository>(() => new RecipeRepository(_repositoryContext));
        _jobRepository = new Lazy<IJobRepository>(() => new JobRepository(_repositoryContext));
    }

    public IRecipeRepository RecipeRepository => _recipeRepository.Value;
    public IJobRepository JobRepository => _jobRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
