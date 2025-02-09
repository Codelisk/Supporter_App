using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Common.Presentation;
using Supporter_Uno.Common.Providers;

namespace Supporter_Uno.Presentation.Authentication;

internal partial class LoginViewModel : BasePageViewModel
{
    public LoginViewModel(BasePageProvider basePageProvider)
        : base(basePageProvider) { }
}
