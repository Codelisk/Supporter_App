using System.ComponentModel.DataAnnotations.Schema;

namespace Supporter_Dtos
{
    [TenantDto(TenantConstants.User)]
    public partial record AzureStorageMappingDto : UserBaseDto<Guid>
    {
        public string IndexName { get; set; }
        public string SystemMessage { get; set; }
        public string ContainerName { get; set; }

        [ForeignKey(nameof(StorageTopicDto))]
        public Guid TopicId { get; set; }
    }
}
