using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using ReactiveUI;

namespace Supporter_Uno.Common;

public partial class BasePageViewModel : ReactiveObject
{
    public BasePageViewModel()
    {
        HandleActivation();
    }

    public virtual void Initialize(NavigationEventArgs e) { }

    protected virtual void HandleActivation() { }

    protected virtual void HandleDeactivation() { }
}
