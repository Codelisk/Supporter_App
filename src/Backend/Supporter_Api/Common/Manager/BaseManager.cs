using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;
using Supporter_Api.Common.Manager.Providers;
using Supporter_Api.Common.Repository;
using Supporter_Api.Common.Services;

namespace Supporter_Api.Common.Manager
{
    public abstract class BaseManager<TDto, TKey, TEntity> : IBaseManager<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct
    {
        public readonly IBaseRepository<TEntity, TKey> _repo;
        private readonly IPaginationService _paginationService;

        public BaseManager(
            IBaseRepository<TEntity, TKey> repo,
            BaseManagerProvider defaultManagerProvider
        )
        {
            _repo = repo;
            _paginationService = defaultManagerProvider.PaginationService;
        }

        public async Task<(List<TDto> objects, int totalRecords)> GetPaginatedAsync(
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            (string, string)[]? additionalSearchFields = null
        )
        {
            var listToUse = await GetAll();

            var paginated = _paginationService.GetPaginated(
                listToUse,
                search,
                searchField,
                page,
                perPage,
                sortBy,
                sortOrder,
                additionalSearchFields: additionalSearchFields
            );

            return (paginated.objects, paginated.totalRecords);
        }

        [Delete]
        public Task Delete(TKey id)
        {
            return _repo.Delete(id);
        }

        public Task<int> DeleteAllAsync(bool areYouSure = false)
        {
            return _repo.DeleteAllAsync(areYouSure);
        }

        public async Task<List<TDto>> GetRangeAsync(List<TKey> ids)
        {
            return ToDtos(await _repo.GetRangeAsync(ids));
        }

        public Task<int> CountAsync()
        {
            return _repo.CountAsync();
        }

        public Task<int> DeleteAllByRangeAsync(List<TKey> ids)
        {
            return _repo.DeleteAllByRangeAsync(ids);
        }

        [GetAll]
        public async Task<List<TDto>> GetAll()
        {
            return ToDtos(await _repo.GetAll()); // Vermutlich List<TDto>
        }

        [Add]
        public async Task<TDto> Add(TDto t)
        {
            return ToDto(await _repo.Add(ToEntity(t)));
        }

        [AddRange]
        public async Task<List<TKey>> AddRange(List<TDto> list)
        {
            return await _repo.AddRange(ToEntities(list));
        }

        [Save]
        public async Task<TDto> Save(TDto t)
        {
            return ToDto(await _repo.Save(ToEntity(t)));
        }

        [Get]
        public async Task<TDto> Get(TKey id)
        {
            var result = await _repo.Get(id);
            if (result is null)
            {
                throw new ArgumentNullException($"Id {id} not found");
            }

            return ToDto(result);
        }

        [GetLast]
        public async Task<TDto?> GetLastOrDefault()
        {
            var result = await _repo.GetLastOrDefault();
            if (result is null)
            {
                return null;
            }
            return ToDto(result);
        }

        public abstract TDto ToDto(TEntity entity);
        public abstract List<TDto> ToDtos(List<TEntity> entity);
        public abstract TEntity ToEntity(TDto entity);
        public abstract List<TEntity> ToEntities(List<TDto> dtos);
    }
}
