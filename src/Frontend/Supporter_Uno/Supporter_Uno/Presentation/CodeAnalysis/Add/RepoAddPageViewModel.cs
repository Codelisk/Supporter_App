using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Add;

public partial class RepoAddPageViewModel : BasePageViewModel
{
    private readonly IAIRepoApi aIRepoApi;

    public RepoAddPageViewModel(BaseVmServices baseVmServices, IAIRepoApi aIRepoApi)
        : base(baseVmServices)
    {
        this.aIRepoApi = aIRepoApi;
    }

    public string Name { get; set; }
    public string Owner { get; set; }

    [RelayCommand]
    public async Task Add()
    {
        await aIRepoApi.Add(new AIRepoDto { Name = Name, Owner = Owner });
        await this.Navigator.GoBack(this);
    }
}
