[TenantDto(TenantConstants.User)]
public partial record AITopicDto : UserBaseDto, INameDto
{
    public required string Name { get; set; }
}
