using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record StorageTopicDto : UserBaseDto<Guid>, INameDto
    {
        public string Name { get; set; }
    }
}
