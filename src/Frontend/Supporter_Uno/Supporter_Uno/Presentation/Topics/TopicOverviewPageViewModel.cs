using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;

namespace Supporter_Uno.Presentation.Topics;

internal partial class TopicOverviewPageViewModel : BasePageViewModel
{
    private readonly INavigator navigator;
    private readonly IAITopicApi aITopicApi;

    public TopicOverviewPageViewModel(INavigator navigator, IAITopicApi aITopicApi)
    {
        this.navigator = navigator;
        this.aITopicApi = aITopicApi;
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        var folder = (e.Parameter as AIFolderDto);
        await aITopicApi.GetAll2();
    }
}
