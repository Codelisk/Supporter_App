namespace Supporter_Api.Common.Repository
{
    public interface IDefaultGlobalRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseBaseDto<TKey>
        where TKey : struct
    {
        void DoBeforeAddOrSave(TEntity t);
        List<TEntity> FilterBeforeReturn(List<TEntity> entities);
        Task<TEntity?> GetLastOrDefault();
    }
}
