using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Topics.Add;

public class AddTopicPageViewModel : BasePageViewModel
{
    private readonly IAITopicApi aITopicApi;

    public AddTopicPageViewModel(BaseVmServices baseVmServices, IAITopicApi aITopicApi)
        : base(baseVmServices)
    {
        this.aITopicApi = aITopicApi;
    }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        Topic.FolderId = (e.Parameter as AIFolderDto).GetId();
    }

    public AITopicDto Topic { get; set; } = new AITopicDto();

    public ICommand AddCommand => new AsyncRelayCommand(OnAddAsync);

    private async Task OnAddAsync()
    {
        await aITopicApi.Add(Topic);
        await Navigator.GoBack(this);
    }
}
