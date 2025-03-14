using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Services.Alert;

internal interface IAlertService
{
    Task<bool> Confirm(object sender, INavigator navigator, string title, string message);
}
