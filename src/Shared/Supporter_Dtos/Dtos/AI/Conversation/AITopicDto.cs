[TenantDto(TenantConstants.User)]
public partial record AITopicDto : UserBaseDto<Guid>, INameDto
{
    public required string Name { get; set; }
}
