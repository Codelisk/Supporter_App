using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Folders;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Auth;

public partial class LoginPageViewModel : BasePageViewModel
{
    private IAuthenticationService _authentication;

    public LoginPageViewModel(
        BaseVmServices baseVmServices,
        IDispatcher dispatcher,
        INavigator navigator,
        IAuthenticationService authentication
    )
        : base(baseVmServices)
    {
        _authentication = authentication;
        Login = new AsyncRelayCommand(DoLogin);
    }

    private async Task DoLogin()
    {
        var success = await _authentication.LoginAsync(Dispatcher);
        if (success)
        {
            await Navigator.NavigateViewAsync<FolderOverviewPage>(
                this,
                qualifier: Qualifiers.ClearBackStack
            );
        }
    }

    public string Title { get; } = "Login";

    public ICommand Login { get; }
}
