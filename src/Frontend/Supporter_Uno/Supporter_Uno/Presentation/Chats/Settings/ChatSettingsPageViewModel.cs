using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats.Settings;

internal partial class ChatSettingsPageViewModel : BasePageViewModel
{
    private readonly IAzureOpenAITrainService azureOpenAITrainService;
    private readonly IAzureOpenAIChatService azureOpenAIChatService;

    AzureTopicMappingDto AzureTopicMappingDto;

    public ChatSettingsPageViewModel(
        BaseVmServices baseVmServices,
        IAzureOpenAITrainService azureOpenAITrainService,
        IAzureOpenAIChatService azureOpenAIChatService
    )
        : base(baseVmServices)
    {
        this.azureOpenAITrainService = azureOpenAITrainService;
        this.azureOpenAIChatService = azureOpenAIChatService;
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
    public string? Description
    {
        get => description;
        set => this.RaiseAndSetIfChanged(ref description, value);
    }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        AzureTopicMappingDto = e.Parameter as AzureTopicMappingDto;
        var assistantClient = azureOpenAIChatService.GetChatClient();
        var assistant = assistantClient.GetAssistant(AzureTopicMappingDto.AssistantId);
        Temperature = assistant.Value.Temperature.GetValueOrDefault(0);
        NucleusSamplingFactor = assistant.Value.NucleusSamplingFactor.GetValueOrDefault(0);
        Model = assistant.Value.Model;
        Instructions = assistant.Value.Instructions;
        Description = assistant.Value.Description;
    }

    public ICommand EditAssistantCommand => new AsyncRelayCommand(OnEditAssistantAsync);

    private async Task OnEditAssistantAsync()
    {
        var result = await azureOpenAIChatService.EditAssistant(
            AzureTopicMappingDto.AssistantId,
            Temperature.HasValue ? ((float?)Temperature) : null,
            NucleusSamplingFactor.HasValue ? ((float)NucleusSamplingFactor) : null,
            Model,
            Instructions,
            Description
        );

        await Navigator.GoBack(this);
    }
}
