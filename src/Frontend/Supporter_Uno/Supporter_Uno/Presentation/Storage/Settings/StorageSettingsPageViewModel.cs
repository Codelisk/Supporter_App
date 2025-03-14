using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.Storage.Settings;

internal partial class StorageSettingsPageViewModel : BasePageViewModel
{
    private readonly IAzureStorageMappingApi azureStorageMappingApi;

    public StorageSettingsPageViewModel(
        BaseVmServices baseVmServices,
        IAzureStorageMappingApi azureStorageMappingApi
    )
        : base(baseVmServices)
    {
        this.azureStorageMappingApi = azureStorageMappingApi;
    }

    public AzureStorageMappingDto AzureStorageMappingDto { get; set; }

    public override void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);
        AzureStorageMappingDto = e.Parameter as AzureStorageMappingDto;
        this.RaisePropertyChanged(nameof(AzureStorageMappingDto));
    }

    [RelayCommand]
    public async Task Set()
    {
        await azureStorageMappingApi.Save(AzureStorageMappingDto);
        await this.Navigator.GoBack(this);
    }
}
