using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AzureRepoMappingDto : UserBaseDto<Guid>
    {
        public string ThreadId { get; set; }
        public string AssistantId { get; set; }

        [ForeignKey(nameof(AIRepoDto))]
        public Guid RepoId { get; set; }
    }
}
