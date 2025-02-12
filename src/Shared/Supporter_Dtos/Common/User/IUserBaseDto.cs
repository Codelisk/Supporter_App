public interface IUserBaseDto<TKey> : IBaseBaseDto<TKey>
    where TKey : struct
{
    bool IsUser(TKey userId);
    public void SetUserId(TKey userId);
}
