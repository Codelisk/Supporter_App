using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supporter_Api.Common.Manager;
using Supporter_Api.Extensions;
using Supporter_Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Supporter_Api.Common.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<TDto, TKey, TEntity>
        : Microsoft.AspNetCore.Mvc.Controller,
            IBaseController<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct, IComparable
    {
        protected readonly IBaseManager<TDto, TKey, TEntity> _manager;

        public BaseController(IBaseManager<TDto, TKey, TEntity> manager)
        {
            _manager = manager;
        }

        [HttpGet("GetPaginated")]
        public async Task<IActionResult> GetPaginatedAsync(
            string search = null,
            string searchField = null,
            int page = 1,
            int perPage = 10,
            string sortBy = null,
            string sortOrder = "asc",
            string filterBy = "",
            string filter = ""
        )
        {
            (string, string)[] additionalSearchFields = null;
            if (!filterBy.IsNullOrEmpty())
            {
                additionalSearchFields = new (string, string)[] { (filterBy, filter) };
            }
            var result = await _manager.GetPaginatedAsync(
                search,
                searchField,
                page,
                perPage,
                sortBy,
                sortOrder,
                additionalSearchFields: additionalSearchFields
            );
            return Ok(new PaginateResult<TDto>(result.objects, result.totalRecords));
        }

        [HttpDelete("DeleteAll")]
        public Task<int> DeleteAllAsync([FromQuery] bool areYouSure)
        {
            return _manager.DeleteAllAsync(areYouSure);
        }

        [HttpDelete("DeleteAllByRange")]
        public Task<int> DeleteAllByRangeAsync(List<TKey> ids)
        {
            return _manager.DeleteAllByRangeAsync(ids);
        }

        [HttpGet("GetRange")]
        public Task<List<TDto>> GetRangeAsync([FromQuery] List<TKey> ids)
        {
            return _manager.GetRangeAsync(ids);
        }

        [HttpGet("Count")]
        public Task<int> CountAsync()
        {
            return _manager.CountAsync();
        }

        [HttpGet("GetAll")]
        [SwaggerOperation(OperationId = "GetAll")]
        public Task<List<TDto>> GetAll()
        {
            return _manager.GetAll();
        }

        [HttpGet("Get")]
        public Task<TDto> Get(TKey id)
        {
            return _manager.Get(id);
        }

        [HttpDelete("Delete")]
        public Task Delete(TKey id)
        {
            return _manager.Delete(id);
        }

        [HttpPost("AddRange")]
        public Task AddRange(List<TDto> addressDtoList)
        {
            return _manager.AddRange(addressDtoList);
        }

        [HttpPost("Add")]
        public Task<TDto> Add(TDto addressDto)
        {
            return _manager.Add(addressDto);
        }

        [HttpGet("GetLastOrDefault")]
        public Task<TDto?> GetLastOrDefault()
        {
            return _manager.GetLastOrDefault();
        }

        [HttpPost("Save")]
        public Task<TDto> Save([FromBody] TDto addressDto)
        {
            return _manager.Save(addressDto);
        }
    }
}
