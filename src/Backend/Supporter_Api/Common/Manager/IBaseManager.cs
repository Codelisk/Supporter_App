using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;

namespace Supporter_Api.Common.Manager
{
    public interface IBaseManager<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct
    {
        TDto ToDto(TEntity entity);

        List<TDto> ToDtos(List<TEntity> entities);

        List<TEntity> ToEntities(List<TDto> dtos);

        TEntity ToEntity(TDto dto);

        [Delete]
        Task Delete(TKey id);

        [Get]
        Task<TDto> Get(TKey id);

        [GetLast]
        Task<TDto?> GetLastOrDefault();

        [GetAll]
        Task<List<TDto>> GetAll();

        [Add]
        Task<TDto> Add(TDto t);

        [AddRange]
        Task<List<TKey>> AddRange(List<TDto> list);

        [Save]
        Task<TDto> Save(TDto t);

        Task<int> DeleteAllAsync(bool areYouSure = false);
        Task<(List<TDto> objects, int totalRecords)> GetPaginatedAsync(
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            (string, string)[]? additionalSearchFields = null
        );
        Task<int> DeleteAllByRangeAsync(List<TKey> ids);
        Task<List<TDto>> GetRangeAsync(List<TKey> ids);
        Task<int> CountAsync();
    }
}
