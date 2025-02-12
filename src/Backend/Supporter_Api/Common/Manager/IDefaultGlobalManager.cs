namespace Supporter_Api.Common.Manager
{
    public interface IDefaultGlobalManager<TDto, TKey, TEntity> : IBaseManager<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct { }
}
