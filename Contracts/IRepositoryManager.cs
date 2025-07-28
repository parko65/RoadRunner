namespace Contracts;
public interface IRepositoryManager
{
    IRecipeRepository Recipe { get; }
    IJobRepository Job { get; }
    IAggregateRepository Aggregate { get; }
    Task SaveAsync();
}
