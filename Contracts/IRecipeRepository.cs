using Entities.Models;

namespace Contracts;
public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetRecipesAsync(bool trackChanges);
    Task<Recipe?> GetRecipeAsync(int id, bool trackChanges);
    void CreateRecipe(Recipe recipe);
}
