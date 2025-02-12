[DtoBase]
public abstract record BaseBaseDto<TKey> : IBaseBaseDto<TKey>
    where TKey : struct
{
    public DateTime CreatedAt { get; set; }

    [GetId]
    public abstract TKey GetId();
}
