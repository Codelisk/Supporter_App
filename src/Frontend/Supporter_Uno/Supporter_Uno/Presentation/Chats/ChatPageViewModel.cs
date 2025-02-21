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
            azureTopics.Last();
        }
        //await chatQuestionApi.GetAll();
    }

    public string Question { get; set; }

    public ICommand ChatCommand => new AsyncRelayCommand(OnChatAsync);

    private async Task OnChatAsync()
    {
        await azureOpenAIChatService.Chat(
            Question,
            threadId: AzureTopicMappingDto.ThreadId,
            assistantId: AzureTopicMappingDto.AssistantId,
            temperature: null
        );
    }
}
