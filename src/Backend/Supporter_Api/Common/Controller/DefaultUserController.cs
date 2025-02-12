using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    public class DefaultUserController<TDto, TEntity> : BaseController<TDto, Guid, TEntity>
        where TDto : UserBaseDto<Guid>
        where TEntity : class, IUserBaseDto<Guid>
    {
        public DefaultUserController(DefaultUserManager<TDto, TEntity> manager)
            : base(manager) { }
    }
}
