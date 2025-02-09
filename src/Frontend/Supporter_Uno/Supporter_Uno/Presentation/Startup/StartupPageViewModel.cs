using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Common.Presentation;
using Supporter_Uno.Common.Providers;
using Supporter_Uno.Presentation.Authentication;
using Supporter_Uno.Presentation.Chats;

namespace Supporter_Uno.Presentation.Startup;

internal partial class StartupPageViewModel : BasePageViewModel
{
    public StartupPageViewModel(BasePageProvider basePageProvider)
        : base(basePageProvider)
    {
        BasePageProvider.Navigator.NavigateViewAsync<ChatPage>(this);
    }
}
