using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Services.Alert;

internal class AlertService : IAlertService
{
    public async Task ShowAlert(object sender, INavigator navigator, string title, string message)
    {
        await navigator.ShowMessageDialogAsync(this, title: title, content: message);
    }

    public async Task<bool> Confirm(
        object sender,
        INavigator navigator,
        string title,
        string message
    )
    {
        var result = await navigator.ShowMessageDialogAsync<string>(
            this,
            title: title,
            content: message,
            buttons: new DialogAction[] { new DialogAction("Ok"), new DialogAction("Abbrechen") }
        );
        return result.Equals("Ok");
    }
}
