using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats.Settings;

internal partial class ChatSettingsPageViewModel : BasePageViewModel
{
    string ParameterAssistant;

    public ChatSettingsPageViewModel(BaseVmServices baseVmServices, IAIApi aIApi)
        : base(baseVmServices)
    {
        this.aIApi = aIApi;
    }

    private double? temperature;
    public double? Temperature
    {
        get => temperature;
        set => this.RaiseAndSetIfChanged(ref temperature, value);
    }
    private double? nucleusSamplingFactor;
    public double? NucleusSamplingFactor
    {
        get => nucleusSamplingFactor;
        set => this.RaiseAndSetIfChanged(ref nucleusSamplingFactor, value);
    }

    private string? model;
    public string? Model
    {
        get => model;
        set => this.RaiseAndSetIfChanged(ref model, value);
    }

    private string? instructions;
    public string? Instructions
    {
        get => instructions;
        set => this.RaiseAndSetIfChanged(ref instructions, value);
    }

    private string? description;
    private readonly IAIApi aIApi;

    public string? Description
    {
        get => description;
        set => this.RaiseAndSetIfChanged(ref description, value);
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        ParameterAssistant = e.Parameter as string;
        var settings = await aIApi.GetSettings(ParameterAssistant);

        Temperature = settings.Temperature.GetValueOrDefault(0);
        NucleusSamplingFactor = settings.NucleusSamplingFactor.GetValueOrDefault(0);
        Model = settings.Model;
        Instructions = settings.Instructions;
        Description = settings.Description;
    }

    public ICommand EditAssistantCommand => new AsyncRelayCommand(OnEditAssistantAsync);

    private async Task OnEditAssistantAsync()
    {
        var result = await aIApi.EditAssistant(
            ParameterAssistant,
            Temperature.HasValue ? ((float?)Temperature) : null,
            NucleusSamplingFactor.HasValue ? ((float)NucleusSamplingFactor) : null,
            Model,
            Instructions,
            Description
        );

        await Navigator.GoBack(this);
    }
}
