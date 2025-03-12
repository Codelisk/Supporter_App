using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_Uno.Services.Settings
{
    internal partial class SettingsService : ISettingsService
    {
        private readonly ISettings settings;

        public SettingsService(ISettings settings)
        {
            this.settings = settings;
        }

        public void Set(string key, string? value)
        {
            settings.Set(key, value);
        }

        public string? Get(string key)
        {
            return settings.Get(key);
        }
    }
}
