using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

[DtoBase]
public abstract record UserBaseDto : BaseBaseDto<Guid>, IUserBaseDto<Guid>
{
    [Id]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool IsUser(Guid userId)
    {
        return userId == UserId;
    }

    public override Guid GetId()
    {
        return this.Id;
    }

    public void SetUserId(Guid userId)
    {
        this.UserId = userId;
    }
}
