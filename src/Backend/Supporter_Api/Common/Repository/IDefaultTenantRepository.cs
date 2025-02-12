namespace Supporter_Api.Common.Repository
{
    public interface IDefaultTenantRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        void DoBeforeAddOrSave(TEntity t);
        List<TEntity> FilterBeforeReturn(List<TEntity> entities);
        Task<TEntity?> GetLastOrDefault();
    }
}
