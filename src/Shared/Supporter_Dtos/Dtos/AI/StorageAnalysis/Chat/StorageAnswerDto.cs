using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record StorageAnswerDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }

        [ForeignKey(nameof(StorageQuestionDto))]
        public Guid QuestionId { get; set; }

        public OwnerEnum Owner { get; set; }
    }
}
