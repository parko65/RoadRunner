using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class RecipeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : IRecipeService
{
    private readonly IRepositoryManager _repository = repository;
    private readonly ILoggerManager _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<RecipeDto>> GetRecipesAsync(bool trackChanges)
    {
        var recipes = await _repository.RecipeRepository.GetRecipesAsync(trackChanges);

        var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);

        return recipeDtos;
    }

    public async Task<RecipeDto> GetRecipeAsync(int id, bool trackChanges)
    {
        var recipe = await _repository.RecipeRepository.GetRecipeAsync(id, trackChanges) ?? throw new RecipeNotFoundException(id);

        var recipeDto = _mapper.Map<RecipeDto>(recipe);

        return recipeDto;
    }

    public async Task<RecipeDto> CreateRecipeAsync(RecipeForCreationDto recipeForCreation)
    {
        var recipeEntity = _mapper.Map<Recipe>(recipeForCreation);

        recipeEntity.Created = DateTime.Now; // Set the Created property to the current time

        _repository.RecipeRepository.CreateRecipe(recipeEntity);
        await _repository.SaveAsync();

        var recipeToReturn = _mapper.Map<RecipeDto>(recipeEntity);

        return recipeToReturn;
    }
}