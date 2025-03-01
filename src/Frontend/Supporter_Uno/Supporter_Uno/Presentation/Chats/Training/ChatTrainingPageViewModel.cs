using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats.Training;

internal partial class ChatTrainingPageViewModel : BasePageViewModel
{
    private readonly IAzureOpenAITrainService azureOpenAITrainService;
    private readonly IAzureOpenAIChatService azureOpenAIChatService;
    private readonly ITrainingMessageApi trainingMessageApi;

    public ChatTrainingPageViewModel(
        BaseVmServices baseVmServices,
        IAzureOpenAITrainService azureOpenAITrainService,
        IAzureOpenAIChatService azureOpenAIChatService,
        ITrainingMessageApi trainingMessageApi
    )
        : base(baseVmServices)
    {
        this.azureOpenAITrainService = azureOpenAITrainService;
        this.azureOpenAIChatService = azureOpenAIChatService;
        this.trainingMessageApi = trainingMessageApi;
    }

    AzureTopicMappingDto AzureTopicMappingDto;
    public string TrainingText { get; set; }
    public ICommand AddTrainingCommand => new AsyncRelayCommand(OnAddTrainingAsync);

    private async Task OnAddTrainingAsync()
    {
        var trainingMessage = new TrainingMessageDto
        {
            Value = "Merk dir das für die Zukunft:\n\n" + TrainingText,
        };
        await trainingMessageApi.Add(trainingMessage);
        var answer = await azureOpenAIChatService.Chat(
            TrainingText,
            AzureTopicMappingDto.ThreadId,
            AzureTopicMappingDto.AssistantId,
            null
        );
    }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        AzureTopicMappingDto = e.Parameter as AzureTopicMappingDto;
    }
}
