using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AITopicDto : UserBaseDto<Guid>, INameDto
    {
        public string Name { get; set; }

        [ForeignKey(nameof(AIFolderDto))]
        public Guid FolderId { get; set; }
    }
}
