using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Conversation.Folders;
using Supporter_Uno.Presentation.Conversation.Topics;
using Supporter_Uno.Presentation.Storage.Overview;

namespace Supporter_Uno.Presentation;

public partial class MainViewModel
{
    private INavigator _navigator;
    private readonly IDispatcher dispatcher;
    private readonly IAuthenticationService authenticationService;
    private string? name;

    public MainViewModel(
        INavigator navigator,
        IDispatcher dispatcher,
        IAuthenticationService authenticationService
    )
    {
        _navigator = navigator;
        this.dispatcher = dispatcher;
        this.authenticationService = authenticationService;
    }

    [RelayCommand]
    public async Task Storage()
    {
        await _navigator.NavigateViewAsync<StorageOverviewPage>(this);
    }

    [RelayCommand]
    public async Task Chat()
    {
        await _navigator.NavigateViewAsync<FolderOverviewPage>(this);
    }

    [RelayCommand]
    public async Task Orderlyze()
    {
        await _navigator.NavigateViewAsync<OrderlyzeDirectLoginPage>(this);
    }

    [RelayCommand]
    public async Task Logout()
    {
        await authenticationService.LogoutAsync(dispatcher);
        await _navigator.NavigateViewAsync<LoginPage>(this);
    }
}
