using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Chats;

public partial class ChatPageViewModel : BasePageViewModel
{
    public ChatPageViewModel(BaseVmServices baseVmServices)
        : base(baseVmServices) { }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        var topic = (e.Parameter as AITopicDto);
    }
}
