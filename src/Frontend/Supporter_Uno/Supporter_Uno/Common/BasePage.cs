using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Uno;

namespace Supporter_Uno.Common;

public partial class BasePage : ReactivePage<BasePageViewModel>
{
    public BasePage() { }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    }
}
