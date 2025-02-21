using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Providers;

public record BaseVmServices(INavigator Navigator, IDispatcher Dispatcher);
