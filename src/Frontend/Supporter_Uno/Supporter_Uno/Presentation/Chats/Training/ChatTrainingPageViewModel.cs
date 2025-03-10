using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats.Training;

internal partial class ChatTrainingPageViewModel : BasePageViewModel
{
    private readonly IChatTrainingMessageApi trainingMessageApi;
    private readonly IAIApi aIApi;

    public ChatTrainingPageViewModel(
        BaseVmServices baseVmServices,
        IChatTrainingMessageApi trainingMessageApi,
        IAIApi aIApi
    )
        : base(baseVmServices)
    {
        this.trainingMessageApi = trainingMessageApi;
        this.aIApi = aIApi;
    }

    AzureTopicMappingDto AzureTopicMappingDto;
    public string TrainingText { get; set; }
    public ICommand AddTrainingCommand => new AsyncRelayCommand(OnAddTrainingAsync);

    private async Task OnAddTrainingAsync()
    {
        this.IsBusy = true;
        try
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

                var answer = await aIApi.Chat(
                    new ChatPayload(
                        TrainingText,
                        AzureTopicMappingDto.ThreadId,
                        AzureTopicMappingDto.AssistantId,
                        null
                    )
                );
                prefix = "\n\nSo geht’s weiter \n\n";
            }
        }
        finally
        {
            this.IsBusy = false;
            await this.Navigator.GoBack(this);
        }
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
