using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;

namespace Supporter_Uno.Presentation.Topics;

internal partial class TopicOverviewPageViewModel : BasePageViewModel
{
    private readonly INavigator navigator;
    private readonly IAITopicApi aITopicApi;
    private readonly IDispatcher dispatcher;

    public TopicOverviewPageViewModel(
        INavigator navigator,
        IAITopicApi aITopicApi,
        IDispatcher dispatcher
    )
    {
        this.navigator = navigator;
        this.aITopicApi = aITopicApi;
        this.dispatcher = dispatcher;
    }

    List<AITopicDto> Topics { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        var folder = (e.Parameter as AIFolderDto);
        await aITopicApi.GetByFolderId(folder!.GetId());
        dispatcher.TryEnqueue(() =>
        {
            this.RaisePropertyChanged(nameof(Topics));
        });
    }
}
