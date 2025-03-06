using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record ChatTrainingMessageDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }

        [ForeignKey(nameof(AITopicDto))]
        public Guid TopicId { get; set; }
    }
}
