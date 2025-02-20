using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Common;

namespace Supporter_Uno.Presentation.Topics;

internal partial class TopicOverviewPageViewModel : BasePageViewModel
{
    private readonly INavigator navigator;

    public TopicOverviewPageViewModel(INavigator navigator)
    {
        this.navigator = navigator;
    }
}
