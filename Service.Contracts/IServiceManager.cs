namespace Service.Contracts;
public interface IServiceManager
{
    IRecipeService RecipeService { get; }
    IJobService JobService { get; }
    IAggregateService AggregateService { get; }
    IDestinationService DestinationService { get; }
    IPLCService PLCService { get; }
}
