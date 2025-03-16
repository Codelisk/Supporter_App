using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.Conversation;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Auth;

public partial class OrderlyzeDirectLoginPageViewModel : BasePageViewModel
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAzureTopicMappingApi azureTopicMappingApi;
    private readonly IAITopicApi aITopicApi;

    public OrderlyzeDirectLoginPageViewModel(
        BaseVmServices baseVmServices,
        IAuthenticationService authenticationService,
        IAzureTopicMappingApi azureTopicMappingApi,
        IAITopicApi aITopicApi,
        ILogger<OrderlyzeDirectLoginPageViewModel> logger
    )
        : base(baseVmServices)
    {
        this._authenticationService = authenticationService;
        this.azureTopicMappingApi = azureTopicMappingApi;
        this.aITopicApi = aITopicApi;
    }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        await DoApiKeyLogin();
    }

    public async Task DoApiKeyLogin()
    {
        var apiKeyLogin = await _authenticationService.LoginAsync(Dispatcher, provider: "ApiKey");

        var lastTopic = (await aITopicApi.GetAll()).Last();

        await Navigator.NavigateViewAsync<ChatPage>(this, data: lastTopic);
    }
}
