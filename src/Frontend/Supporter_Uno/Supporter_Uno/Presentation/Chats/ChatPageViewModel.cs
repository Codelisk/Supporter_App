using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenAI.Assistants;
using ReactiveUI;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Chats.Settings;
using Supporter_Uno.Presentation.Chats.Training;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats;

public partial class ChatPageViewModel : BasePageViewModel
{
    private readonly IAzureTopicMappingApi azureTopicMappingApi;
    private readonly IChatQuestionApi chatQuestionApi;
    private readonly IChatAnswerApi chatAnswerApi;
    private readonly IAzureOpenAIChatService azureOpenAIChatService;

    public ChatPageViewModel(
        BaseVmServices baseVmServices,
        IAzureTopicMappingApi azureTopicMappingApi,
        IChatQuestionApi chatQuestionApi,
        IChatAnswerApi chatAnswerApi,
        IAzureOpenAIChatService azureOpenAIChatService
    )
        : base(baseVmServices)
    {
        this.azureTopicMappingApi = azureTopicMappingApi;
        this.chatQuestionApi = chatQuestionApi;
        this.chatAnswerApi = chatAnswerApi;
        this.azureOpenAIChatService = azureOpenAIChatService;
    }

    private AzureTopicMappingDto AzureTopicMappingDto;

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        AITopicDto topic = (e.Parameter as AITopicDto)!;
        if (topic is null)
        {
            throw new ArgumentNullException(nameof(topic));
        }
        var test = await azureTopicMappingApi.GetAll();
        var azureTopics = await azureTopicMappingApi.GetByTopicId(topic.GetId());
        if (azureTopics.Count == 0)
        {
            var newAssistant = await azureOpenAIChatService.CreateAssistant(topic.Name, 0);
            var newThread = await azureOpenAIChatService.CreateThreadAsync(topic.Name);
            AzureTopicMappingDto = await azureTopicMappingApi.Add(
                new AzureTopicMappingDto
                {
                    AssistantId = newAssistant.Value.Id,
                    ThreadId = newThread.Value.Id,
                    TopicId = topic.GetId(),
                }
            );
        }
        else
        {
            AzureTopicMappingDto = azureTopics.Last();
        }
        //await chatQuestionApi.GetAll();
    }

    public string Question { get; set; }

#pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public Task<string> OnChatAsync()
#pragma warning restore OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    {
        try
        {
            this.IsBusy = true;
            return azureOpenAIChatService.Chat(
                Question,
                threadId: AzureTopicMappingDto.ThreadId,
                assistantId: AzureTopicMappingDto.AssistantId,
                temperature: null
            );
        }
        finally
        {
            this.IsBusy = false;
            Question = string.Empty;
            this.RaisePropertyChanged(nameof(Question));
        }
    }

    public ICommand SettingsCommand => new AsyncRelayCommand<AzureTopicMappingDto>(OnSettings);

    private async Task OnSettings(AzureTopicMappingDto? dto)
    {
        await this.Navigator.NavigateViewAsync<ChatSettingsPage>(this, data: AzureTopicMappingDto);
    }

    public ICommand TrainingCommand => new AsyncRelayCommand<AzureTopicMappingDto>(OnTraining);

    private async Task OnTraining(AzureTopicMappingDto? dto)
    {
        await this.Navigator.NavigateViewAsync<ChatTrainingPage>(this, data: AzureTopicMappingDto);
    }
}
