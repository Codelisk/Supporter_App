[TenantDto(TenantConstants.User)]
public partial record AIFolderDto : UserBaseDto<Guid>, INameDto
{
    public required string Name { get; set; }
}
