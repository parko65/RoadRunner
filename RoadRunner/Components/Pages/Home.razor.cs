using AutoMapper;
using Enums;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RoadRunner.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace RoadRunner.Components.Pages;
public partial class Home : IDisposable
{
    private readonly IServiceManager _service;
    private readonly IMapper _mapper;

    public Home(IServiceManager service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    private List<RecipeModel> _recipes { get; set; } = [];
    private RecipeModel? _selectedRecipe;

    private List<DestinationModel> _destinations { get; set; } = [];    

    private IQueryable<JobModel>? _jobs;
    private JobModel? _selectedJob;

    private JobForCreation _jobForCreation { get; set; } = new();

    private EditContext _editContext = default!;

    private bool formInvalid = true;

    private bool DeferredLoading = false;
    private string? activeId = "overview";

    private Microsoft.FluentUI.AspNetCore.Components.Color lampColor = Microsoft.FluentUI.AspNetCore.Components.Color.Error;

    FluentTab? changedto;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(_jobForCreation);
        _editContext.OnFieldChanged += HandleFieldChanged;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadRecipesAsync();
        await LoadDestinationsAsync();
        await LoadJobsAsync();
        EnsureSelected();
    }

    private async Task LoadRecipesAsync()
    {
        var recipes = await _service.RecipeService.GetRecipesAsync(trackChanges: false);

        // Map the recipes to the RecipeModel
        var recipeModels = _mapper.Map<IEnumerable<RecipeModel>>(recipes);

        _recipes = [.. recipeModels];
    }

    private async Task LoadDestinationsAsync()
    {
        var destinations = await _service.DestinationService.GetDestinationsAsync(trackChanges: false);
        var destinationModels = _mapper.Map<IEnumerable<DestinationModel>>(destinations);

        _destinations = destinationModels.ToList();
    }

    private async Task LoadJobsAsync()
    {
        var status = JobStatus.Pending;

        var jobs = await _service.JobService.GetJobsByStatusAsync(status, trackChanges: false);
        
        var jobModels = _mapper.Map<IEnumerable<JobModel>>(jobs);        

        _jobs = jobModels.AsQueryable();
    }

    private async Task HandleValidSubmit()
    {
        if (_selectedRecipe is not null)
            _jobForCreation.RecipeId = _selectedRecipe.Id;

        var job = _mapper.Map<JobForCreationDto>(_jobForCreation);        
        var createdJob = await _service.JobService.CreateJobAsync(job);

        await LoadJobsAsync();

        _editContext = new EditContext(_jobForCreation);
        _editContext.OnValidationStateChanged += ValidationChanged;
        _editContext.NotifyValidationStateChanged();
    }    

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        // Handle field changes if necessary
        formInvalid = !_editContext.Validate();
        StateHasChanged();
    }

    private void ValidationChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        formInvalid = true;
        _editContext.OnFieldChanged -= HandleFieldChanged;        
        _editContext = new EditContext(_jobForCreation);
        _editContext.OnFieldChanged += HandleFieldChanged;
        _editContext.OnValidationStateChanged -= ValidationChanged;
    }

    private void HandleRecipeCreated(RecipeModel recipe)
    {
        _recipes.Add(recipe);
    }

    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
        activeId = tab.Id;
    }

    private void HandleRowClick(FluentDataGridRow<JobModel> row)
    {
        _selectedJob = row.Item;

        //// Since we now have a selected aggregate, we can populate the AggregateForCreation for editing but we need to parse the MaterialNumber to string
        //AggregateForCreation.MaterialNumber = _selectedAggregate!.MaterialNumber.ToString();
        //AggregateForCreation.Name = _selectedAggregate.Name;

        //editMode = true;
    }

    private string GetRowClass(JobModel job)
    {
        return _selectedJob != null && _selectedJob.Id == job.Id ? "selected-row" : string.Empty;
    }

    private void EnsureSelected()
    {
        if (_recipes.Count > 0 && _selectedRecipe == null)
        {
            _selectedRecipe = _recipes[0];
        }
    }

    private async Task StartMixingAsync()
    {
        var isMixerReady = await _service.PLCService.CheckMixerReadyAsync();
        if (isMixerReady)
        {
            // Logic to start mixing
            lampColor = Microsoft.FluentUI.AspNetCore.Components.Color.Success;

        }
        else
        {
            // Handle the case where the mixer is not ready
            // For example, show a message to the user
            lampColor = Microsoft.FluentUI.AspNetCore.Components.Color.Error;
        }
    }

    public void Dispose()
    {
        _editContext.OnFieldChanged -= HandleFieldChanged;
        _editContext.OnValidationStateChanged -= ValidationChanged;
    }
}
