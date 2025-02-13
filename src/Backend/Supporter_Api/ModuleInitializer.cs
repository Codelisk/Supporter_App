using Codelisk.GeneratorAttributes.GeneralAttributes.ModuleInitializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Supporter_Api.Common.Services;

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
            services.TryAddScoped<IPaginationService, PaginationService>();
            services.TryAddScoped<BaseUserRepositoryProvider>();
            services.TryAddScoped<BaseManagerProvider>();
            AddServices(services);
            AddManagerServices(services);
            AddRepositoryServices(services);
            AddDatabaseServices(services);
            AddControllerServices(services);
        }
    }
}
