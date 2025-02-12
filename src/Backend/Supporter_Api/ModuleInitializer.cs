using Codelisk.GeneratorAttributes.GeneralAttributes.ModuleInitializers;
using Microsoft.AspNetCore.Identity;

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
            AddServices(services);
            AddManagerServices(services);
            AddRepositoryServices(services);
            AddDatabaseServices(services);
            AddControllerServices(services);
        }
    }
}
