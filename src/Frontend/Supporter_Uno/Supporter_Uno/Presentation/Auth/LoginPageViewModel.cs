using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Folders;

namespace Supporter_Uno.Presentation.Auth;

public partial class LoginPageViewModel : BasePageViewModel
{
    private IAuthenticationService _authentication;

    private INavigator _navigator;
    private IDispatcher _dispatcher;

    public LoginPageViewModel(
        IDispatcher dispatcher,
        INavigator navigator,
        IAuthenticationService authentication
    )
    {
        _dispatcher = dispatcher;
        _navigator = navigator;
        _authentication = authentication;
        Login = new AsyncRelayCommand(DoLogin);
    }

    private async Task DoLogin()
    {
        var success = await _authentication.LoginAsync(_dispatcher);
        if (success)
        {
            await _navigator.NavigateViewAsync<FolderOverviewPage>(
                this,
                qualifier: Qualifiers.ClearBackStack
            );
        }
    }

    public string Title { get; } = "Login";

    public ICommand Login { get; }
}
