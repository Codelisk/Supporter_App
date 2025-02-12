using Codelisk.GeneratorAttributes.WebAttributes.Repository;
using Supporter_Api.Common.Repository;
using Supporter_Api.Database;

namespace Supporter_Api.Common.Repository
{
    [DefaultRepository(TenantConstants.Tenant)]
    public class DefaultTenantRepository<TEntity>
        : BaseRepository<TEntity, Guid>,
            IDefaultTenantRepository<TEntity>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        public DefaultTenantRepository(MyDbContext myDbContext)
            : base(myDbContext) { }

        public override void DoBeforeAddOrSave(TEntity t)
        {
            throw new NotImplementedException();
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
