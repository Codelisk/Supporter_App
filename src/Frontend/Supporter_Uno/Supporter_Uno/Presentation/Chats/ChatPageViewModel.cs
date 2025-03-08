using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats.Settings;
using Supporter_Uno.Presentation.Chats.Training;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats;

public partial class ChatPageViewModel : BasePageViewModel
{
    private readonly IAzureTopicMappingApi azureTopicMappingApi;
    private readonly IChatQuestionApi chatQuestionApi;
    private readonly IChatAnswerApi chatAnswerApi;
    private readonly IConfiguration configuration;
    private readonly ILogger<OrderlyzeDirectLoginPageViewModel> logger;
    private readonly IAIApi aiApi;

    public ChatPageViewModel(
        BaseVmServices baseVmServices,
        IAzureTopicMappingApi azureTopicMappingApi,
        IChatQuestionApi chatQuestionApi,
        IChatAnswerApi chatAnswerApi,
        IConfiguration configuration,
        ILogger<OrderlyzeDirectLoginPageViewModel> logger,
        IAIApi aiApi
    )
        : base(baseVmServices)
    {
        this.azureTopicMappingApi = azureTopicMappingApi;
        this.chatQuestionApi = chatQuestionApi;
        this.chatAnswerApi = chatAnswerApi;
        this.configuration = configuration;
        this.logger = logger;
        this.aiApi = aiApi;
    }

    private AzureTopicMappingDto AzureTopicMappingDto;

    public void SetKey()
    {
        try
        {
            var settings = configuration.GetSection("AzureOpenAI");
            string endpoint = settings["Endpoint"];
            this.ApiKey =
                settings["ApiKey"] ?? throw new InvalidOperationException("API Key not found!");
            logger.LogInformation(ApiKey);
            this.RaisePropertyChanged(nameof(ApiKey));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error setting API Key");
        }
    }

    public string ApiKey { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        SetKey();
        AITopicDto topic = (e.Parameter as AITopicDto)!;
        if (topic is null)
        {
            throw new ArgumentNullException(nameof(topic));
        }

        var azureTopics = await azureTopicMappingApi.GetByTopicId(topic.GetId());
        if (azureTopics.Count == 0)
        {
            var newAssistant = await aiApi.CreateAssistant(topic.Name, 0);
            var newThread = await aiApi.CreateThreadAsync(topic.Name);
            AzureTopicMappingDto = await azureTopicMappingApi.Add(
                new AzureTopicMappingDto
                {
                    AssistantId = newAssistant,
                    ThreadId = newThread,
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

    private ChatQuestionDto? LastQuestion;
#pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public async Task OnChatAsync()
#pragma warning restore OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    {
        try
        {
            this.IsBusy = true;
            var chatQuestion = await chatQuestionApi.Add(
                new ChatQuestionDto { TopicId = AzureTopicMappingDto.TopicId, Value = Question }
            );
            LastQuestion = chatQuestion;
            this.Answer = await aiApi.Chat(
                Question,
                threadId: AzureTopicMappingDto.ThreadId,
                assistantId: AzureTopicMappingDto.AssistantId,
                temperature: null
            );
            await chatAnswerApi.Add(
                new ChatAnswerDto
                {
                    QuestionId = chatQuestion.GetId(),
                    Owner = OwnerEnum.Bot,
                    Value = Answer,
                }
            );
        }
        finally
        {
            this.IsBusy = false;
            Question = string.Empty;
            this.RaisePropertyChanged(nameof(Question));
            this.RaisePropertyChanged(nameof(Answer));
        }
    }

    public string Answer { get; set; }
    public ICommand AskCommand => new AsyncRelayCommand(OnChatAsync);

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

    public ICommand PreviousCommand => new AsyncRelayCommand(OnPrevious);

    private async Task OnPrevious()
    {
        this.IsBusy = true;
        try
        {
            if (LastQuestion is null)
            {
                var questions = await chatQuestionApi.GetByTopicId(AzureTopicMappingDto.TopicId);
                LastQuestion = questions.LastOrDefault();
            }
            else
            {
                var questions = await chatQuestionApi.GetByTopicId(AzureTopicMappingDto.TopicId);

                // Sortiere die Fragen nach CreatedAt absteigend
                var previousQuestion = questions
                    .OrderByDescending(q => q.CreatedAt)
                    .FirstOrDefault(q => q.CreatedAt < LastQuestion.CreatedAt);
                LastQuestion = previousQuestion;
            }

            if (LastQuestion is null)
            {
                return;
            }

            Question = LastQuestion.Value;
            Answer =
                $"**Frage:**\n{Question}\n\n"
                + $"**Antwort:**\n"
                + $"{(await chatAnswerApi.GetByQuestionId(LastQuestion.GetId())).LastOrDefault()?.Value}";
        }
        finally
        {
            this.IsBusy = false;
            this.RaisePropertyChanged(nameof(Answer));
        }
    }
}
