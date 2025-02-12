public interface IBaseBaseDto<TKey> : ICreatedAt
{
    TKey GetId();
}
