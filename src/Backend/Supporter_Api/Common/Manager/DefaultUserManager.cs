using Codelisk.GeneratorAttributes.WebAttributes.Manager;
using Supporter_Api.Common.Manager.Providers;
using Supporter_Api.Common.Repository;

namespace Supporter_Api.Common.Manager
{
    [DefaultManager(TenantConstants.User)]
    public abstract class DefaultUserManager<TDto, TEntity> : BaseManager<TDto, Guid, TEntity>
        where TDto : UserBaseDto<Guid>, IUserBaseDto<Guid>
        where TEntity : class, IUserBaseDto<Guid>
    {
        public DefaultUserManager(
            DefaultUserRepository<TEntity> repo,
            BaseManagerProvider defaultManagerProvider
        )
            : base(repo, defaultManagerProvider) { }
    }
}
