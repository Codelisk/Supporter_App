using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;
using Supporter_AI.Services.OpenAI.AzureAI;

namespace Supporter_AI
{
    public static class Initializer
    {
        public static void AddAIServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddAIClient(configuration);
            services.AddTransient<IAzureOpenAIChatService, AzureOpenAIChatService>();
        }

        private static void AddAIClient(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var settings = configuration.GetSection("AzureOpenAI");
            string endpoint = settings["Endpoint"];
            string apiKey =
                settings["ApiKey"] ?? throw new InvalidOperationException("API Key not found!");

            services.AddSingleton(
                new AzureOpenAIClient(
                    new Uri(endpoint),
                    new System.ClientModel.ApiKeyCredential(apiKey)
                )
            );
        }
    }
}
