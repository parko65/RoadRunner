using AutoMapper;
using Microsoft.FluentUI.AspNetCore.Components;
using RoadRunner.Models;
using Service.Contracts;

namespace RoadRunner.Components.Pages;
public partial class Home
{
    private readonly IServiceManager _service;
    private readonly IMapper _mapper;

    public Home(IServiceManager service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    private List<RecipeModel> _recipes { get; set; } = new();
    private RecipeModel? _selectedRecipe;

    private bool DeferredLoading = false;
    private string? activeId = "tab-1";

    FluentTab? changedto;

    protected override async Task OnInitializedAsync()
    {
        await LoadRecipesAsync();
    }

    private async Task LoadRecipesAsync()
    {
        var recipes = await _service.RecipeService.GetRecipesAsync(trackChanges: false);

        // Map the recipes to the RecipeModel
        var recipeModels = _mapper.Map<IEnumerable<RecipeModel>>(recipes);

        _recipes = recipeModels.ToList();
    }

    private void HandleRecipeCreated(RecipeModel recipe)
    {
        _recipes.Add(recipe);        
    }

    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
    }
}
