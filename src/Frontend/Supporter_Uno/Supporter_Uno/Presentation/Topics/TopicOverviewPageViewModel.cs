using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Chats;
using Supporter_Uno.Presentation.Topics.Add;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Topics;

public partial class TopicOverviewPageViewModel : BasePageViewModel
{
    private readonly IAITopicApi aITopicApi;

    public TopicOverviewPageViewModel(BaseVmServices services, IAITopicApi aITopicApi)
        : base(services)
    {
        this.aITopicApi = aITopicApi;
    }

    public ICollection<AITopicDto> Topics { get; set; }
    private AIFolderDto Folder;

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        Folder = (e.Parameter as AIFolderDto);
        Topics = await aITopicApi.GetByFolderId(Folder!.GetId());
        Dispatcher.TryEnqueue(() =>
        {
            this.RaisePropertyChanged(nameof(Topics));
        });
    }

    public ICommand TopicCommand => new AsyncRelayCommand<AITopicDto>(OnTopicAsync);

    private async Task OnTopicAsync(AITopicDto topic)
    {
        await Navigator.NavigateViewAsync<ChatPage>(this, data: topic);
    }

    public ICommand AddCommand => new AsyncRelayCommand(OnAddAsync);

    private async Task OnAddAsync()
    {
        await Navigator.NavigateViewAsync<AddTopicPage>(this, data: Folder);
    }
}
