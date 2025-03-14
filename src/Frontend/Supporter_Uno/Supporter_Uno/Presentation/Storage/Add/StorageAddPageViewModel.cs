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
    private readonly IAIApi aIApi;

    public StorageAddPageViewModel(
        BaseVmServices baseVmServices,
        IStorageTopicApi storageTopicApi,
        IAzureStorageMappingApi azureStorageMappingApi,
        IAIApi aIApi
    )
        : base(baseVmServices)
    {
        this.storageTopicApi = storageTopicApi;
        this.azureStorageMappingApi = azureStorageMappingApi;
        this.aIApi = aIApi;
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

        var assistant = await aIApi.CreateAssistant(Name, null, SystemMessage);
        var thread = await aIApi.CreateThreadAsync(Name);
        await azureStorageMappingApi.Add(
            new AzureStorageMappingDto
            {
                TopicId = topicResult.GetId(),
                IndexName = IndexName,
                ContainerName = ContainerName,
                SystemMessage = SystemMessage,
                ThreadId = thread,
                AssistantId = assistant,
            }
        );
        await this.Navigator.GoBack(this);
    }
}
