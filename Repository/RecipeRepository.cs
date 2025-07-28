using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;
public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
{
    public RecipeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Recipe>> GetRecipesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToListAsync();

    public async Task<Recipe?> GetRecipeAsync(int id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRecipe(Recipe recipe) =>
        Create(recipe);
}