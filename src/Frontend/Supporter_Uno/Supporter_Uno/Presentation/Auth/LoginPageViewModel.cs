using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.CodeAnalysis.Overview;
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
        this.IsBusy = true;
    }

    [RelayCommand]
    public async Task DoApiKeyLogin()
    {
        var apiKeyLogin = await _authentication.LoginAsync(Dispatcher, provider: "ApiKey");

        await Navigator.NavigateViewAsync<FolderOverviewPage>(
            this,
            qualifier: Qualifiers.ClearBackStack
        );
    }

    [RelayCommand]
    public async Task Login()
    {
        try
        {
            var success = await _authentication.LoginAsync(Dispatcher);
            if (success)
            {
                await Navigator.NavigateViewAsync<FolderOverviewPage>(this);
            }
        }
        catch (Exception ex)
        {
            await Navigator.ShowMessageDialogAsync(
                this,
                title: "Fehler",
                content: "Login abgebrochen"
            );
        }
    }

    [RelayCommand]
    public async Task LoginCode()
    {
        try
        {
            var success = await _authentication.LoginAsync(Dispatcher, provider: "Msal");
            if (success)
            {
                await Navigator.NavigateViewAsync<RepoOverviewPage>(this);
            }
        }
        catch (Exception ex)
        {
            await Navigator.ShowMessageDialogAsync(
                this,
                title: "Fehler",
                content: "Login abgebrochen"
            );
        }
    }

    public string Title { get; } = "Login";
}
