using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Supporer_Shared.Models.AI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Conversation.Settings;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Chat;

internal partial class RepoChatPageViewModel : BasePageViewModel
{
    private readonly IAzureRepoMappingApi azureTopicMappingApi;
    private readonly ICodeQuestionApi chatQuestionApi;
    private readonly ICodeAnswerApi chatAnswerApi;
    private readonly IConfiguration configuration;
    private readonly ILogger<RepoChatPageViewModel> logger;
    private readonly IAIApi aiApi;

    public RepoChatPageViewModel(
        BaseVmServices baseVmServices,
        IAzureRepoMappingApi azureTopicMappingApi,
        ICodeQuestionApi chatQuestionApi,
        ICodeAnswerApi chatAnswerApi,
        IConfiguration configuration,
        ILogger<RepoChatPageViewModel> logger,
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

    private AzureRepoMappingDto AzureTopicMappingDto;

    public string Question { get; set; }

    private CodeQuestionDto? LastQuestion;

    public string Answer { get; set; }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        AzureTopicMappingDto = (e.Parameter as AzureRepoMappingDto)!;
        if (AzureTopicMappingDto is null)
        {
            throw new ArgumentNullException(nameof(AzureTopicMappingDto));
        }
    }

    [RelayCommand]
    public async Task Ask()
    {
        try
        {
            this.IsBusy = true;
            var chatQuestion = await chatQuestionApi.Add(
                new CodeQuestionDto { RepoId = AzureTopicMappingDto.RepoId, Value = Question }
            );
            LastQuestion = chatQuestion;
            this.Answer = await aiApi.Chat(
                new ChatPayload(
                    Question,
                    AzureTopicMappingDto.ThreadId,
                    AzureTopicMappingDto.AssistantId,
                    null
                )
            );
            await chatAnswerApi.Add(
                new CodeAnswerDto
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

    [RelayCommand]
    private async Task Previous()
    {
        this.IsBusy = true;
        try
        {
            if (LastQuestion is null)
            {
                var questions = await chatQuestionApi.GetByRepoId(AzureTopicMappingDto.RepoId);
                LastQuestion = questions.LastOrDefault();
            }
            else
            {
                var questions = await chatQuestionApi.GetByRepoId(AzureTopicMappingDto.RepoId);

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

    [RelayCommand]
    private async Task Settings(AzureTopicMappingDto? dto)
    {
        await this.Navigator.NavigateViewAsync<ChatSettingsPage>(
            this,
            data: AzureTopicMappingDto.AssistantId
        );
    }
}
