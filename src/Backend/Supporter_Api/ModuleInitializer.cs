using Azure;
using Azure.Core;
using Azure.Search.Documents;
using Azure.Storage.Blobs;
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
            var section = configurationManager.GetSection("AzureBlob");
            var connectionString = section.GetValue<string>("ConnectionString");
            services.TryAddScoped<BlobServiceClient>(_ =>
            {
                return new BlobServiceClient(connectionString);
            });
            services.TryAddScoped<IBlobStorageService, BlobStorageService>();
            services.TryAddScoped<IPaginationService, PaginationService>();
            services.TryAddScoped<ISearchService, AzureSearchService>();
            services.TryAddScoped<ICodeAnalyzeService, CodeAnalyzeService>();
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
