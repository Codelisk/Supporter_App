using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Storage.Add;
using Supporter_Uno.Presentation.Storage.Chat;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Storage.Overview;

internal partial class StorageOverviewPageViewModel : BasePageViewModel
{
    private readonly IStorageTopicApi storageTopicApi;
    private readonly IAuthenticationService authenticationService;

    public StorageOverviewPageViewModel(
        BaseVmServices baseVmServices,
        IStorageTopicApi storageTopicApi,
        IAuthenticationService authenticationService
    )
        : base(baseVmServices)
    {
        this.storageTopicApi = storageTopicApi;
        this.authenticationService = authenticationService;
    }

    public ICollection<StorageTopicDto> StorageTopics { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        StorageTopics = await storageTopicApi.GetAll();
        this.RaisePropertyChanged(nameof(StorageTopics));
    }

    [RelayCommand]
    public async Task Add()
    {
        await Navigator.NavigateViewAsync<StorageAddPage>(this);
    }

    [RelayCommand]
    public async Task Storage(StorageTopicDto storageTopicDto)
    {
        await Navigator.NavigateViewAsync<StorageChatPage>(this, data: storageTopicDto);
    }

    [RelayCommand]
    public async Task Logout()
    {
        await authenticationService.LogoutAsync(Dispatcher);
        await Navigator.NavigateViewAsync<LoginPage>(this, qualifier: Qualifiers.ClearBackStack);
    }
}
