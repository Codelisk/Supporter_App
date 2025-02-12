using Codelisk.GeneratorAttributes.WebAttributes.Manager;
using Supporter_Api.Common.Manager.Providers;
using Supporter_Api.Common.Repository;

namespace Supporter_Api.Common.Manager
{
    [DefaultManager(TenantConstants.User)]
    public class DefaultUserManager<TDto, TKey, TEntity> : BaseManager<TDto, TKey, TEntity>
        where TDto : UserBaseDto<TKey>, IUserBaseDto<TKey>
        where TEntity : class, IUserBaseDto<TKey>
        where TKey : struct
    {
        public DefaultUserManager(
            IBaseRepository<TEntity, TKey> repo,
            BaseManagerProvider defaultManagerProvider
        )
            : base(repo, defaultManagerProvider) { }

        public override TDto ToDto(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<TDto> ToDtos(List<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        public override List<TEntity> ToEntities(List<TDto> dtos)
        {
            throw new NotImplementedException();
        }

        public override TEntity ToEntity(TDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
