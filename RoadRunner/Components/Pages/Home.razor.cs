using Microsoft.FluentUI.AspNetCore.Components;
using Service.Contracts;
using System.Diagnostics;

namespace RoadRunner.Components.Pages;
public partial class Home
{
    private readonly IServiceManager _service;

    public Home(IServiceManager service)
    {
        _service = service;
    }

    private bool DeferredLoading = false;
    private string? activeId = "tab-1";

    FluentTab? changedto;

    protected override async Task OnInitializedAsync()
    {
        var result = await _service.PLCService.CheckMixerReadyAsync();
        if (result)
        {
            Debug.WriteLine("Mixer is ready.");
        }
        else
        {
            Debug.WriteLine("Mixer is not ready.");
        }
    }


    private void HandleOnTabChange(FluentTab tab)
    {
        changedto = tab;
    }
}
