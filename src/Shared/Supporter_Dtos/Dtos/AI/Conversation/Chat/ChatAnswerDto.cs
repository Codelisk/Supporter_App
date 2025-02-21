using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record ChatAnswerDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }

        [ForeignKey(nameof(ChatQuestionDto))]
        public Guid QuestionId { get; set; }

        public OwnerEnum Owner { get; set; }
    }
}
