using Supporter_Api.Common.Manager;

namespace Supporter_Api.Common.Controller
{
    public class DefaultTenantController<TDto, TKey, TEntity> : BaseController<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct, IComparable
    {
        public DefaultTenantController(IBaseManager<TDto, TKey, TEntity> manager)
            : base(manager) { }
    }
}
