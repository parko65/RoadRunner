namespace Contracts;
public interface IRepositoryManager
{
    IRecipeRepository RecipeRepository { get; }
    IJobRepository JobRepository { get; }
    Task SaveAsync();
}
