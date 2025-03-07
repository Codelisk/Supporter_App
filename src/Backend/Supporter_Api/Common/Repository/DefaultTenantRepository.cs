﻿using Codelisk.GeneratorAttributes.WebAttributes.Repository;
using Supporter_Api.Common.Repository;
using Supporter_Api.Database;

namespace Supporter_Api.Common.Repository
{
    [DefaultRepository(TenantConstants.Tenant)]
    public class DefaultTenantRepository<TEntity>
        : BaseRepository<TEntity, Guid>,
            IDefaultTenantRepository<TEntity>
        where TEntity : class, ITenantBaseDto<Guid>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DefaultTenantRepository(BaseUserRepositoryProvider baseUserRepositoryProvider)
            : base(baseUserRepositoryProvider.DbContext)
        {
            _contextAccessor = baseUserRepositoryProvider.HttpContextAccessor;
        }

        public override void DoBeforeAddOrSave(TEntity t)
        {
            t.SetTenantId(GetTenantObjectId());
        }

        public override List<TEntity> FilterBeforeReturn(List<TEntity> entities)
        {
            var tenantId = GetTenantObjectId();
            return entities.Where(x => x.IsTenant(tenantId)).ToList();
        }

        public override Task<TEntity?> GetLastOrDefault()
        {
            throw new NotImplementedException();
        }

        public Guid GetTenantObjectId()
        {
            var user = _contextAccessor.HttpContext?.User?.FindFirst(
                "http://schemas.microsoft.com/identity/claims/tenantid"
            );
            if (user is not null)
            {
                return Guid.Parse(user.Value);
            }
            var apiKey = _contextAccessor
                .HttpContext?.Request.Headers["Authorization"]
                .FirstOrDefault();
            if (apiKey is not null)
            {
                return Guid.Parse("111");
            }

            throw new AccessViolationException();
        }
    }
}
