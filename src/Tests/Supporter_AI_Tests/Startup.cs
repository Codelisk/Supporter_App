using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supporter_AI;
using Supporter_AI.Services.OpenAI;

namespace Supporter_AI_Tests
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureHostConfiguration(configBuilder =>
            {
                configBuilder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddUserSecrets<Startup>()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilder)
        {
            services.AddAIServices(hostBuilder.Configuration);
        }
    }
}
