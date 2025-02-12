namespace Supporter_Api.Common.Manager
{
    public interface IDefaultUserManager<TDto, TEntity> : IBaseManager<TDto, Guid, TEntity>
        where TDto : UserBaseDto<Guid>
        where TEntity : class, IUserBaseDto<Guid> { }
}
