using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Presentation.CodeAnalysis.Add;
using Supporter_Uno.Presentation.CodeAnalysis.Analyze;
using Supporter_Uno.Presentation.CodeAnalysis.Chat;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Overview;

public partial class RepoOverviewPageViewModel : BasePageViewModel
{
    private readonly IAIRepoApi aIRepoApi;
    private readonly IAzureRepoMappingApi azureRepoMappingApi;
    private readonly IAIApi aIApi;

    public RepoOverviewPageViewModel(
        BaseVmServices baseVmServices,
        IAIRepoApi aIRepoApi,
        IAzureRepoMappingApi azureRepoMappingApi,
        IAIApi aIApi
    )
        : base(baseVmServices)
    {
        this.aIRepoApi = aIRepoApi;
        this.azureRepoMappingApi = azureRepoMappingApi;
        this.aIApi = aIApi;
    }

    public ICollection<AIRepoDto> Repos { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        Repos = await aIRepoApi.GetAll();
        this.RaisePropertyChanged(nameof(Repos));
    }

    [RelayCommand]
    public async Task Add()
    {
        await this.Navigator.NavigateViewAsync<RepoAddPage>(this);
    }

    [RelayCommand]
    public async Task Repo(AIRepoDto aIRepo)
    {
        var byRepoId = await azureRepoMappingApi.GetByRepoId(aIRepo.Id);
        if (byRepoId.Count == 0)
        {
            var newAssistant = await aIApi.CreateAssistant(
                new CreateAssistantsPayload(aIRepo.Name, 0, false, false)
            );
            var newThread = await aIApi.CreateThreadAsync(false, false);
            var repoMapping = await azureRepoMappingApi.Add(
                new AzureRepoMappingDto
                {
                    AssistantId = newAssistant,
                    ThreadId = newThread,
                    RepoId = aIRepo.GetId(),
                }
            );
            await this.Navigator.NavigateViewAsync<FileRepoAnalyzePage>(this, data: repoMapping);
        }
        else
        {
            await this.Navigator.NavigateViewAsync<RepoChatPage>(this, data: byRepoId.Last());
        }
    }
}
