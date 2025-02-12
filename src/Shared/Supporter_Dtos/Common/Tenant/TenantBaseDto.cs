[DtoBase]
public abstract record TenantBaseDto<TKey> : BaseBaseDto<TKey>, ITenantBaseDto<TKey>
    where TKey : struct
{
    [Id]
    public required TKey Id { get; set; }

    public required TKey TenantId { get; set; }

    public override TKey GetId()
    {
        return this.Id;
    }

    public bool IsTenant(TKey tenantId)
    {
        return tenantId.Equals(tenantId);
    }

    public void SetTenantId(TKey tenantId)
    {
        this.TenantId = tenantId;
    }
}
