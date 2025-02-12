using Codelisk.GeneratorAttributes.WebAttributes.Manager;
using Supporter_Api.Common.Manager.Providers;
using Supporter_Api.Common.Repository;

namespace Supporter_Api.Common.Manager
{
    [DefaultManager(TenantConstants.Tenant)]
    public abstract class DefaultTenantManager<TDto, TEntity>
        : BaseManager<TDto, Guid, TEntity>,
            IDefaultTenantManager<TDto, TEntity>
        where TDto : TenantBaseDto<Guid>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        public DefaultTenantManager(
            IDefaultTenantRepository<TEntity> repo,
            BaseManagerProvider defaultManagerProvider
        )
            : base(repo, defaultManagerProvider) { }
    }
}
