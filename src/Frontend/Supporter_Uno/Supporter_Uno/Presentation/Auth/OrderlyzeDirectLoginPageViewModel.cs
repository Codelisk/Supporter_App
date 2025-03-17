using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Conversation;
using Supporter_Uno.Presentation.Storage.Chat;
using Supporter_Uno.Presentation.Storage.Overview;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Auth;

public partial class OrderlyzeDirectLoginPageViewModel : BasePageViewModel
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAzureTopicMappingApi azureTopicMappingApi;
    private readonly IAITopicApi aITopicApi;
    private readonly IStorageTopicApi storageTopicApi;

    public OrderlyzeDirectLoginPageViewModel(
        BaseVmServices baseVmServices,
        IAuthenticationService authenticationService,
        IAzureTopicMappingApi azureTopicMappingApi,
        IAITopicApi aITopicApi,
        IStorageTopicApi storageTopicApi,
        ILogger<OrderlyzeDirectLoginPageViewModel> logger
    )
        : base(baseVmServices)
    {
        this._authenticationService = authenticationService;
        this.azureTopicMappingApi = azureTopicMappingApi;
        this.aITopicApi = aITopicApi;
        this.storageTopicApi = storageTopicApi;
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        await DoApiKeyLogin();
    }

    public async Task DoApiKeyLogin()
    {
        var apiKeyLogin = await _authenticationService.LoginAsync(Dispatcher, provider: "ApiKey");

        var lastTopic = (await storageTopicApi.GetAll()).Last();

        await Navigator.NavigateViewAsync<StorageChatPage>(this, data: lastTopic);
    }
}
