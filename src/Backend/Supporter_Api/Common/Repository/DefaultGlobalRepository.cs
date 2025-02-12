using Supporter_Api.Database;

namespace Supporter_Api.Common.Repository
{
    public class DefaultGlobalRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>
        where TEntity : BaseBaseDto<TKey>, IUserBaseDto<TKey>
        where TKey : struct
    {
        public DefaultGlobalRepository(MyDbContext myDbContext)
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
