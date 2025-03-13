using Azure;
using Azure.Core;
using Azure.Search.Documents;
using Codelisk.GeneratorAttributes.GeneralAttributes.ModuleInitializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Graph.ExternalConnectors;
using Supporter_AI;
using Supporter_Api.Common.Services;
using Supporter_Api.Services;

namespace Supporter_Api
{
    [RepositoryModuleInitializer("AddRepositoryServices")]
    [ManagerModuleInitializer("AddManagerServices")]
    [DatabaseModuleInitializer("AddDatabaseServices")]
    [ControllerModuleInitializer("AddControllerServices")]
    public partial class ModuleInitializer
    {
        partial void AddServices(IServiceCollection services);

        partial void AddManagerServices(IServiceCollection services);

        partial void AddRepositoryServices(IServiceCollection services);

        partial void AddDatabaseServices(IServiceCollection services);

        partial void AddControllerServices(IServiceCollection services);

        public void Configure(
            IServiceCollection services,
            IConfigurationManager configurationManager
        )
        {
            var settings = configurationManager.GetSection("AzureSearch");
            string endpoint = settings["Endpoint"];
            string indexName = settings["IndexName"];
            string apiKey = settings["ApiKey"];

            services.TryAddScoped<SearchClient>(_ => new SearchClient(
                new Uri(endpoint),
                indexName,
                new AzureKeyCredential(apiKey)
            ));
            services.TryAddScoped<IPaginationService, PaginationService>();
            services.TryAddScoped<ISearchService, AzureSearchService>();
            services.TryAddScoped<IReadRetrieveReadChatService, ReadRetrieveReadChatService>();
            services.TryAddScoped<BaseUserRepositoryProvider>();
            services.TryAddScoped<BaseManagerProvider>();
            Initializer.AddAIServices(services, configurationManager);
            AddServices(services);
            AddManagerServices(services);
            AddRepositoryServices(services);
            AddDatabaseServices(services);
            AddControllerServices(services);
        }
    }
}
