using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record TrainingMessageDto : UserBaseDto<Guid>, IValueDto
    {
        public string Value { get; set; }
    }
}
