using AutoMapper;
using Contracts;
using Entities.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;
public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IRecipeService> _recipeService;
    private readonly Lazy<IJobService> _jobService;
    private readonly Lazy<IAggregateService> _aggregateService;
    private readonly Lazy<IPLCService> _plcService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IOptionsMonitor<PLCConfiguration> plcMonitor)
    {
        _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, logger, mapper));
        _jobService = new Lazy<IJobService>(() => new JobService(repositoryManager, logger, mapper));
        _aggregateService = new Lazy<IAggregateService>(() => new AggregateService(repositoryManager, logger, mapper));
        _plcService = new Lazy<IPLCService>(() => new PLCService(plcMonitor, logger));
    }

    public IRecipeService RecipeService => _recipeService.Value;
    public IJobService JobService => _jobService.Value;
    public IAggregateService AggregateService => _aggregateService.Value;
    public IPLCService PLCService => _plcService.Value;
}
