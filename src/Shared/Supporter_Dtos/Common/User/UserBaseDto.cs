[DtoBase]
[PrimaryKey(nameof(Id))]
public abstract record UserBaseDto<TKey> : BaseBaseDto<TKey>, IUserBaseDto<TKey>
    where TKey : struct
{
    [Id]
    public TKey Id { get; set; }

    public TKey UserId { get; set; }

    public override TKey GetId()
    {
        return this.Id;
    }

    public bool IsUser(TKey userId)
    {
        var result = UserId.Equals(userId);
        return result;
    }

    public void SetUserId(TKey userId)
    {
        this.UserId = userId;
    }
}
