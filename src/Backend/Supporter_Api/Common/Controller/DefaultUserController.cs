using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    public class DefaultUserController<TDto, TKey, TEntity> : BaseController<TDto, TKey, TEntity>
        where TDto : UserBaseDto<TKey>
        where TEntity : class, IUserBaseDto<TKey>
        where TKey : struct, IComparable
    {
        public DefaultUserController(IBaseManager<TDto, TKey, TEntity> manager)
            : base(manager) { }
    }
}
