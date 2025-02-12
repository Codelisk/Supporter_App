using Microsoft.AspNetCore.Mvc;

namespace Supporter_Api.Common.Controller
{
    public interface IBaseController<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct, IComparable
    {
        Task<int> DeleteAllAsync(bool areYouSure);
        Task<int> DeleteAllByRangeAsync(List<TKey> ids);
        Task<IActionResult> GetPaginatedAsync(
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            string filterBy = "",
            string filter = ""
        );
        Task<List<TDto>> GetRangeAsync(List<TKey> ids);
        Task<int> CountAsync();
        Task<List<TDto>> GetAll();
        Task<TDto> Get(TKey id);
        Task Delete(TKey id);
        Task AddRange(List<TDto> addressDtoList);
        Task<TDto> Add(TDto addressDto);
        Task<TDto?> GetLastOrDefault();
        Task<TDto> Save(TDto addressDto);
    }
}
