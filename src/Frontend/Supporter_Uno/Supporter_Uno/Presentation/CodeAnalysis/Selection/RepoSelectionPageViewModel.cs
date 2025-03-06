using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Selection;

public partial class RepoSelectionPageViewModel : BasePageViewModel
{
    public RepoSelectionPageViewModel(BaseVmServices baseVmServices)
        : base(baseVmServices) { }

    public string Url { get; set; }

    [RelayCommand]
    public async Task AnalyzeRepo() { }
}
