using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record StorageQuestionDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }

        [ForeignKey(nameof(StorageTopicDto))]
        public Guid TopicId { get; set; }
    }
}
