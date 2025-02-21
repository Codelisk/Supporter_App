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
    public BasePage()
    {
        this.DataContextChanged += BasePage_DataContextChanged;
    }

    private void BasePage_DataContextChanged(
        FrameworkElement sender,
        DataContextChangedEventArgs args
    )
    {
        if (!IsInitialized && args.NewValue is BasePageViewModel viewModel)
        {
            IsInitialized = true;
            viewModel.Initialize(_navigationEventArgs);
        }
    }

    private bool IsInitialized = false;

    private NavigationEventArgs _navigationEventArgs;

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _navigationEventArgs = e;
        base.OnNavigatedTo(e);
    }
}
