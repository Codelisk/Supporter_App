using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    public class DefaultTenantController<TDto, TEntity> : BaseController<TDto, Guid, TEntity>
        where TDto : TenantBaseDto<Guid>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        public DefaultTenantController(DefaultTenantManager<TDto, TEntity> manager)
            : base(manager) { }
    }
}
