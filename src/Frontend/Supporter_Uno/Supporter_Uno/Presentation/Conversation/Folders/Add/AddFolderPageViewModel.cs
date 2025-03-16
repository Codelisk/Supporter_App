using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Conversation.Folders.Add;

public partial class AddFolderPageViewModel : BasePageViewModel
{
    private readonly IAIFolderApi aIFolderApi;

    public AddFolderPageViewModel(BaseVmServices baseVmServices, IAIFolderApi aIFolderApi)
        : base(baseVmServices)
    {
        this.aIFolderApi = aIFolderApi;
    }

    public AIFolderDto Folder { get; set; } = new AIFolderDto();

    public ICommand AddCommand => new AsyncRelayCommand(OnAddAsync);

    private async Task OnAddAsync()
    {
        try
        {
            await aIFolderApi.Add(Folder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("TEST");
        }
        await Navigator.GoBack(this);
    }
}
