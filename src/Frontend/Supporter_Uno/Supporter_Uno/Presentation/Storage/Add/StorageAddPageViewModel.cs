using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Storage.Add;

internal partial class StorageAddPageViewModel : BasePageViewModel
{
    private readonly IStorageTopicApi storageTopicApi;
    private readonly IAzureStorageMappingApi azureStorageMappingApi;

    public StorageAddPageViewModel(
        BaseVmServices baseVmServices,
        IStorageTopicApi storageTopicApi,
        IAzureStorageMappingApi azureStorageMappingApi
    )
        : base(baseVmServices)
    {
        this.storageTopicApi = storageTopicApi;
        this.azureStorageMappingApi = azureStorageMappingApi;
    }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
    }

    public string Name { get; set; }
    public string IndexName { get; set; }
    public string ContainerName { get; set; }
    public string SystemMessage { get; set; }

    [RelayCommand]
    public async Task Add()
    {
        var topicResult = await storageTopicApi.Add(new StorageTopicDto { Name = Name });
        await azureStorageMappingApi.Add(
            new AzureStorageMappingDto
            {
                TopicId = topicResult.GetId(),
                IndexName = IndexName,
                ContainerName = ContainerName,
                SystemMessage = SystemMessage,
            }
        );
        await this.Navigator.GoBack(this);
    }
}
