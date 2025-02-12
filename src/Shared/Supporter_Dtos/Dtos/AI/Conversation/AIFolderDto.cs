[TenantDto(TenantConstants.User)]
public partial record AIFolderDto : UserBaseDto, INameDto
{
    public required string Name { get; set; }
}
