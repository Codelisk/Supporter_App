using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats.Training;

internal partial class ChatTrainingPageViewModel : BasePageViewModel
{
    private readonly IAzureOpenAITrainService azureOpenAITrainService;
    private readonly IAzureOpenAIChatService azureOpenAIChatService;
    private readonly IChatTrainingMessageApi trainingMessageApi;

    public ChatTrainingPageViewModel(
        BaseVmServices baseVmServices,
        IAzureOpenAITrainService azureOpenAITrainService,
        IAzureOpenAIChatService azureOpenAIChatService,
        IChatTrainingMessageApi trainingMessageApi
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
        const int maxLength = 15000;
        var trainingTexts = SplitText(TrainingText, maxLength);
        string prefix = "Merk dir das für die Zukunft:\n\n";

        foreach (var textPart in trainingTexts)
        {
            var trainingMessage = new ChatTrainingMessageDto
            {
                Value = prefix + textPart,
                TopicId = AzureTopicMappingDto.TopicId,
            };
            await trainingMessageApi.Add(trainingMessage);
            prefix = "\n\nSo geht’s weiter \n\n";
        }

        var answer = await azureOpenAIChatService.Chat(
            TrainingText,
            AzureTopicMappingDto.ThreadId,
            AzureTopicMappingDto.AssistantId,
            null
        );
    }

    private List<string> SplitText(string text, int maxLength)
    {
        var parts = new List<string>();
        for (int i = 0; i < text.Length; i += maxLength)
        {
            parts.Add(text.Substring(i, Math.Min(maxLength, text.Length - i)));
        }
        return parts;
    }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        AzureTopicMappingDto = e.Parameter as AzureTopicMappingDto;
    }
}
