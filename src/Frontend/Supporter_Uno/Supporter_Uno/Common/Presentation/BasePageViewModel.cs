using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Uno.Common.Providers;

namespace Supporter_Uno.Common.Presentation;

internal partial class BasePageViewModel : ReactiveObject, IBaseViewModel
{
    public readonly BasePageProvider BasePageProvider;

    public BasePageViewModel(BasePageProvider basePageProvider)
    {
        BasePageProvider = basePageProvider;
    }

    public virtual void OnNavigatedTo(NavigationEventArgs e) { }
}
