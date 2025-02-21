using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats;

public partial class ChatPageViewModel : BasePageViewModel
{
    private readonly IAzureTopicMappingApi azureTopicMappingApi;
    private readonly IChatQuestionApi chatQuestionApi;
    private readonly IChatAnswerApi chatAnswerApi;

    public ChatPageViewModel(
        BaseVmServices baseVmServices,
        IAzureTopicMappingApi azureTopicMappingApi,
        IChatQuestionApi chatQuestionApi,
        IChatAnswerApi chatAnswerApi
    )
        : base(baseVmServices)
    {
        this.azureTopicMappingApi = azureTopicMappingApi;
        this.chatQuestionApi = chatQuestionApi;
        this.chatAnswerApi = chatAnswerApi;
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        var topic = (e.Parameter as AITopicDto);
        var azureTopics = await azureTopicMappingApi.GetByTopicId(topic.GetId());
        if (azureTopics.Count == 0) { }
        await chatQuestionApi.GetAll();
    }
}
