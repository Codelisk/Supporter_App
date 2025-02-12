[DtoBase]
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
        return userId.Equals(userId);
    }

    public void SetUserId(TKey userId)
    {
        this.UserId = userId;
    }
}
