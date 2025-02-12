using Codelisk.GeneratorAttributes.WebAttributes.Manager;
using Supporter_Api.Common.Manager.Providers;
using Supporter_Api.Common.Repository;

namespace Supporter_Api.Common.Manager
{
    [DefaultManager]
    public abstract class DefaultGlobalManager<TDto, TKey, TEntity>
        : BaseManager<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>, IBaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct
    {
        public DefaultGlobalManager(
            IBaseRepository<TEntity, TKey> repo,
            BaseManagerProvider defaultManagerProvider
        )
            : base(repo, defaultManagerProvider) { }
    }
}
