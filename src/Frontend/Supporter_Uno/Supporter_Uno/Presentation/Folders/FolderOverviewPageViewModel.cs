using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Folders.Add;
using Supporter_Uno.Presentation.Topics;
using Supporter_Uno.Presentation.Topics.Add;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Folders;

public partial class FolderOverviewPageViewModel : BasePageViewModel
{
    private readonly IAIFolderApi aIFolderApi;

    public FolderOverviewPageViewModel(BaseVmServices services, IAIFolderApi aIFolderApi)
        : base(services)
    {
        this.aIFolderApi = aIFolderApi;
    }

    public List<AIFolderDto> Folders { get; set; }
    public ICommand FolderCommand => new AsyncRelayCommand<AIFolderDto>(OnFolderAsync);

    private async Task OnFolderAsync(AIFolderDto aIFolderDto)
    {
        await Navigator.NavigateViewAsync<TopicOverviewPage>(this, data: aIFolderDto);
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        Folders = (await this.aIFolderApi.GetAll()).ToList();
        Dispatcher.TryEnqueue(() =>
        {
            this.RaisePropertyChanged(nameof(Folders));
        });
    }

    public ICommand AddCommand => new AsyncRelayCommand(OnAddAsync);

    private async Task OnAddAsync()
    {
        await Navigator.NavigateViewAsync<AddFolderPage>(this);
    }
}
