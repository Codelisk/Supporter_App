using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using ReactiveUI;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Common;

public partial class BasePageViewModel : ReactiveObject
{
    protected readonly INavigator Navigator;
    protected readonly IDispatcher Dispatcher;

    public BasePageViewModel(BaseVmServices baseVmServices)
    {
        this.Navigator = baseVmServices.Navigator;
        this.Dispatcher = baseVmServices.Dispatcher;
    }

    public virtual void Initialize(NavigationEventArgs e) { }
}
