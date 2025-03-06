using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record CodeQuestionDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }

        [ForeignKey(nameof(AIRepoDto))]
        public Guid RepoId { get; set; }
    }
}
