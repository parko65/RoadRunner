using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IRecipeService> _recipeService;
    private readonly Lazy<IJobService> _jobService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, logger, mapper));
        _jobService = new Lazy<IJobService>(() => new JobService(repositoryManager, logger, mapper));
    }

    public IRecipeService RecipeService => _recipeService.Value;
    public IJobService JobService => _jobService.Value;
}
