using Codelisk.GeneratorAttributes.WebAttributes.Controller;
using Microsoft.AspNetCore.Mvc;
using Supporter_Api.Common.Manager;
using Supporter_Api.Extensions;
using Supporter_Api.Models;

namespace Supporter_Api.Common.Controller
{
    [DefaultController]
    public class DefaultGlobalController<TDto, TKey, TEntity> : BaseController<TDto, TKey, TEntity>
        where TDto : BaseBaseDto<TKey>
        where TEntity : class, IBaseBaseDto<TKey>
        where TKey : struct, IComparable
    {
        protected readonly IBaseManager<TDto, TKey, TEntity> _manager;

        public DefaultGlobalController(IBaseManager<TDto, TKey, TEntity> manager)
            : base(manager)
        {
            _manager = manager;
        }
    }
}
