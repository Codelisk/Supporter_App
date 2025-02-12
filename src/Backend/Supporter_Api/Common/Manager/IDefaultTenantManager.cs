namespace Supporter_Api.Common.Manager
{
    public interface IDefaultTenantManager<TDto, TEntity> : IBaseManager<TDto, Guid, TEntity>
        where TDto : TenantBaseDto<Guid>
        where TEntity : class, ITenantBaseDto<Guid> { }
}
