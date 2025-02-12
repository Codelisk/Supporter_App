namespace Supporter_Api.Common.Repository
{
    public interface IDefaultUserRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IUserBaseDto<Guid>
    {
        void DoBeforeAddOrSave(TEntity t);
        List<TEntity> FilterBeforeReturn(List<TEntity> entities);
        Task<TEntity?> GetLastOrDefault();
    }
}
