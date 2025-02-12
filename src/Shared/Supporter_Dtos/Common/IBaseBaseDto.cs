[DtoBaseInterface]
public interface IBaseBaseDto<TKey> : ICreatedAt
    where TKey : struct
{
    TKey GetId();
}
