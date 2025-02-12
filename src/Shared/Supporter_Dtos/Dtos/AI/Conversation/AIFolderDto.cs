namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AIFolderDto : UserBaseDto<Guid>, INameDto
    {
        public string Name { get; set; }
    }
}
