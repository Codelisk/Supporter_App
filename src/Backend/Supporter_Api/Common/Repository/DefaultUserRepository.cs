using Codelisk.GeneratorAttributes.WebAttributes.Repository;
using Supporter_Api.Common.Repository.Providers;
using Supporter_Api.Database;

namespace Supporter_Api.Common.Repository
{
    [DefaultRepository(TenantConstants.User)]
    public class DefaultUserRepository<TEntity>
        : BaseRepository<TEntity, Guid>,
            IDefaultUserRepository<TEntity>
        where TEntity : class, IUserBaseDto<Guid>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultUserRepository(BaseUserRepositoryProvider baseUserRepositoryProvider)
            : base(baseUserRepositoryProvider.DbContext)
        {
            _contextAccessor = baseUserRepositoryProvider.HttpContextAccessor;
        }

        public override void DoBeforeAddOrSave(TEntity t)
        {
            t.SetUserId(Guid.Parse(_contextAccessor.HttpContext.User.Identity.Name));
        }

        public override List<TEntity> FilterBeforeReturn(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<TEntity?> GetLastOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
