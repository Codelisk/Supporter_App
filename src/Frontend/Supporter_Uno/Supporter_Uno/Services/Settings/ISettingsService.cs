using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Services.Settings
{
    internal interface ISettingsService
    {
        string? Get(string key);
        void Set(string key, string? value);
    }
}
