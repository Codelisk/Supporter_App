using Codelisk.GeneratorAttributes.WebAttributes.Controller;
using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    [DefaultController(TenantConstants.Tenant)]
    public class DefaultTenantController<TDto, TEntity> : BaseController<TDto, Guid, TEntity>
        where TDto : TenantBaseDto<Guid>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        public DefaultTenantController(DefaultTenantManager<TDto, TEntity> manager)
            : base(manager) { }
    }
}
