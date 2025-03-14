using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.CodeAnalysis.Chat;
using Supporter_Uno.Presentation.Storage.Settings;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Storage.Chat;

internal partial class StorageChatPageViewModel : BasePageViewModel
{
    private readonly IAzureStorageMappingApi azureTopicMappingApi;
    private readonly IStorageQuestionApi chatQuestionApi;
    private readonly IStorageAnswerApi chatAnswerApi;
    private readonly IConfiguration configuration;
    private readonly ILogger<RepoChatPageViewModel> logger;
    private readonly IAIApi aiApi;

    public StorageChatPageViewModel(
        BaseVmServices baseVmServices,
        IAzureStorageMappingApi azureTopicMappingApi,
        IStorageQuestionApi chatQuestionApi,
        IStorageAnswerApi chatAnswerApi,
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

    private AzureStorageMappingDto AzureStorageMappingDto;

    public string Question { get; set; }

    private StorageQuestionDto? LastQuestion;

    public string Answer { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        var storageTopicDto = (e.Parameter as StorageTopicDto)!;
        if (storageTopicDto is null)
        {
            throw new ArgumentNullException(nameof(storageTopicDto));
        }
        AzureStorageMappingDto = (
            await azureTopicMappingApi.GetByTopicId(storageTopicDto.GetId())
        ).Last();
    }

    [RelayCommand]
    public async Task Ask()
    {
        try
        {
            this.IsBusy = true;
            var chatQuestion = await chatQuestionApi.Add(
                new StorageQuestionDto
                {
                    TopicId = AzureStorageMappingDto.TopicId,
                    Value = Question,
                }
            );
            LastQuestion = chatQuestion;
            this.Answer = await aiApi.ChatWithSearch(
                AzureStorageMappingDto.IndexName,
                AzureStorageMappingDto.SystemMessage,
                chatQuestion.Value
            );
            await chatAnswerApi.Add(
                new StorageAnswerDto
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
                var questions = await chatQuestionApi.GetByTopicId(AzureStorageMappingDto.TopicId);
                LastQuestion = questions.LastOrDefault();
            }
            else
            {
                var questions = await chatQuestionApi.GetByTopicId(AzureStorageMappingDto.TopicId);

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
        await this.Navigator.NavigateViewAsync<StorageSettingsPage>(
            this,
            data: AzureStorageMappingDto
        );
    }
}
