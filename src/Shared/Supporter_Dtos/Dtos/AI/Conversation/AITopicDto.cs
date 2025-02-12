namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AITopicDto : UserBaseDto<Guid>, INameDto
    {
        public string Name { get; set; }
    }
}
