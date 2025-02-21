using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AzureTopicMappingDto : UserBaseDto<Guid>
    {
        public string ThreadId { get; set; }
        public string AssistantId { get; set; }

        [ForeignKey(nameof(AITopicDto))]
        public Guid TopicId { get; set; }
    }
}
