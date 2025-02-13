using Supporter_Uno.Presentation.Auth;
using Supporter_Uno.Presentation.Chats;

namespace Supporter_Uno.Presentation;

public partial class MainViewModel
{
    private INavigator _navigator;
    private readonly IDispatcher dispatcher;
    private readonly IAuthenticationService authenticationService;
    private string? name;

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        IDispatcher dispatcher,
        IAuthenticationService authenticationService
    )
    {
        _navigator = navigator;
        this.dispatcher = dispatcher;
        this.authenticationService = authenticationService;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);
    }

    public string? Title { get; }

    public ICommand GoToSecond { get; }

    private async Task GoToSecondView()
    {
        await authenticationService.LogoutAsync(dispatcher: this.dispatcher);
        await _navigator.NavigateViewAsync<LoginPage>(this);
    }
}
