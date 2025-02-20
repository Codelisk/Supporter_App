using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using ReactiveUI;

namespace Supporter_Uno.Common;

public partial class BasePageViewModel : ReactiveObject
{
    public BasePageViewModel() { }

    public virtual void OnNavigatedTo(NavigationEventArgs e) { }
}
