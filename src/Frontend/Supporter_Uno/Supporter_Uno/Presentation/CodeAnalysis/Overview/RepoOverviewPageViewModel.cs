using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Overview;

public partial class RepoOverviewPageViewModel : BasePageViewModel
{
    private readonly IAIRepoApi aIRepoApi;

    public RepoOverviewPageViewModel(BaseVmServices baseVmServices, IAIRepoApi aIRepoApi)
        : base(baseVmServices)
    {
        this.aIRepoApi = aIRepoApi;
    }

    public ICollection<AIRepoDto> Repos { get; set; }

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        Repos = await aIRepoApi.GetAll();
        this.RaisePropertyChanged(nameof(Repos));
    }
}
