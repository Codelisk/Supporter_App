public interface IUserBaseDto<TKey>
{
    bool IsUser(TKey userId);
    public void SetUserId(TKey userId);
}
