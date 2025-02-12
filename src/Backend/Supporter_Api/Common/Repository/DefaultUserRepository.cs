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
            t.SetUserId(GetUserObjectId());
        }

        public override List<TEntity> FilterBeforeReturn(List<TEntity> entities)
        {
            var userId = GetUserObjectId();
            return entities.Where(x => x.IsUser(userId)).ToList();
        }

        public override Task<TEntity?> GetLastOrDefault()
        {
            throw new NotImplementedException();
        }

        public Guid GetUserObjectId()
        {
            var user = _contextAccessor.HttpContext?.User;
            return Guid.Parse(
                user?.FindFirst(
                    "http://schemas.microsoft.com/identity/claims/objectidentifier"
                ).Value
            );
        }
    }
}
