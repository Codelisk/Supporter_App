public interface ITenantBaseDto<TKey> : IBaseBaseDto<TKey>
    where TKey : struct
{
    bool IsTenant(TKey tenantId);
    public void SetTenantId(TKey tenantId);
}
