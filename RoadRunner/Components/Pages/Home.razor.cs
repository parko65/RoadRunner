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
    private string? activeId = "overview";

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

    private async Task HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
        activeId = tab.Id;

        IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();
        SpeechOptions options = new SpeechOptions()
        {
            Pitch = 1.2f,
            Volume = 0.55f,
            Locale = locales.FirstOrDefault(x => x.Name == "Microsoft Zira")
        };

        await TextToSpeech.Default.SpeakAsync($"{activeId}", options);
    }
}
