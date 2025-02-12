using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;

namespace Supporter_Api.Common.Repository
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct
    {
        [Delete]
        Task<bool> Delete(TKey id);

        [Get]
        Task<TEntity?> Get(TKey id);

        [GetAll]
        Task<List<TEntity>> GetAll();

        [Save]
        Task<TEntity> Save(TEntity t);

        [Add]
        Task<TEntity> Add(TEntity t);

        [AddRange]
        Task<List<TKey>> AddRange(List<TEntity> list);

        [GetLast]
        Task<TEntity?> GetLastOrDefault();

        Task<int> DeleteAllAsync(bool areYouSure = false);
        Task<int> DeleteAllByRangeAsync(List<TKey> ids);
        Task<List<TEntity>> GetRangeAsync(List<TKey> ids);
        Task<int> CountAsync();
        Task<List<TEntity>> GetAll(List<TKey> ids);

        Task<List<TEntity>> EntityByPropertyAsync<TValue>(
            string propertyName,
            TValue propertyValue
        );
    }
}
