using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Topics;

namespace Supporter_Uno.Presentation.Folders;

internal partial class FolderOverviewPageViewModel : BasePageViewModel
{
    private readonly IAIFolderApi aIFolderApi;
    private readonly IDispatcher dispatcher;
    private readonly INavigator navigator;

    public FolderOverviewPageViewModel(
        IAIFolderApi aIFolderApi,
        IDispatcher dispatcher,
        INavigator navigator
    )
    {
        this.aIFolderApi = aIFolderApi;
        this.dispatcher = dispatcher;
        this.navigator = navigator;
    }

    public List<AIFolderDto> Folders { get; set; }
    public ICommand MyCommand => new AsyncRelayCommand<string>(OnMyAsync);

    private async Task OnMyAsync(string name)
    {
        await navigator.NavigateViewAsync<TopicOverviewPage>(this);
    }

    public override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        await Task.Delay(500);
        Folders = (await this.aIFolderApi.GetAll()).ToList();
        dispatcher.TryEnqueue(() =>
        {
            this.RaisePropertyChanged(nameof(Folders));
        });
    }
}
