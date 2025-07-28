using Shared.DataTransferObjects;

namespace Service.Contracts;
public interface IRecipeService
{
    Task<IEnumerable<RecipeDto>> GetRecipesAsync(bool trackChanges);
    Task<RecipeDto> GetRecipeAsync(int id, bool trackChanges);
    Task<RecipeDto> CreateRecipeAsync(RecipeForCreationDto recipeForCreation);
}
