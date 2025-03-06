namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AIRepoDto : UserBaseDto<Guid>, INameDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
