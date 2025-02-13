using Codelisk.GeneratorAttributes.WebAttributes.Controller;
using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    [DefaultController(TenantConstants.User)]
    public class DefaultUserController<TDto, TEntity> : BaseController<TDto, Guid, TEntity>
        where TDto : UserBaseDto<Guid>
        where TEntity : class, IUserBaseDto<Guid>
    {
        public DefaultUserController(IDefaultUserManager<TDto, TEntity> manager)
            : base(manager) { }
    }
}
