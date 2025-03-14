using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Supporer_Shared.Models.Azure;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;
using Supporter_Uno.Services.Alert;
using Windows.Storage.Pickers;

namespace Supporter_Uno.Presentation.Storage.Settings;

internal partial class StorageSettingsPageViewModel : BasePageViewModel
{
    private readonly IAzureStorageMappingApi azureStorageMappingApi;
    private readonly IStorageTopicApi storageTopicApi;
    private readonly IAzureBlobApi azureBlobApi;
    private readonly IAIApi aIApi;
    private readonly IAlertService alertService;

    public StorageSettingsPageViewModel(
        BaseVmServices baseVmServices,
        IAzureStorageMappingApi azureStorageMappingApi,
        IStorageTopicApi storageTopicApi,
        IAzureBlobApi azureBlobApi,
        IAIApi aIApi,
        IAlertService alertService
    )
        : base(baseVmServices)
    {
        this.azureStorageMappingApi = azureStorageMappingApi;
        this.storageTopicApi = storageTopicApi;
        this.azureBlobApi = azureBlobApi;
        this.aIApi = aIApi;
        this.alertService = alertService;
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
        await aIApi.EditAssistant(
            AzureStorageMappingDto.AssistantId,
            null,
            null,
            null,
            AzureStorageMappingDto.SystemMessage,
            null
        );

        await azureStorageMappingApi.Save(AzureStorageMappingDto);

        await this.Navigator.GoBack(this);
    }

    [RelayCommand]
    public async Task DeleteStorage()
    {
        if (await alertService.Confirm(this, Navigator, "Sicher?", "Sind Sie sicher?"))
        {
            await azureStorageMappingApi.Delete(AzureStorageMappingDto.GetId());
            await storageTopicApi.Delete(AzureStorageMappingDto.TopicId);
            await this.Navigator.GoBack(this);
        }
    }

    [RelayCommand]
    public async Task UpdateStorage()
    {
        this.IsBusy = true;
        try
        {
            await PickFolder();
            foreach (var item in Contents)
            {
                if (string.IsNullOrEmpty(item.Item2))
                {
                    continue;
                }
                await azureBlobApi.UploadFiles(
                    new UploadFilePayload(
                        AzureStorageMappingDto.ContainerName,
                        item.Item1,
                        item.Item2
                    )
                );
            }
        }
        finally
        {
            this.IsBusy = false;
            await this.Navigator.GoBack(this);
        }
    }

    private async Task PickFolder()
    {
        var picker = new FolderPicker();
        picker.FileTypeFilter.Add("*"); // Erforderlich für UWP-Apps

        // Get the current window's HWND by passing a Window object
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle((App.Current as App).MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        var folder = await picker.PickSingleFolderAsync();
        if (folder != null)
        {
            await ProcessFolderAsync(folder);
        }
    }

    List<(string, string)> Contents = new();

    private async Task ProcessFolderAsync(StorageFolder folder)
    {
        var files = await folder.GetFilesAsync();
        var subFolders = await folder.GetFoldersAsync();

        foreach (var file in files)
        {
            try
            {
                string content = await FileIO.ReadTextAsync(file);
                Contents.Add((file.Name, content));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        foreach (var subFolder in subFolders)
        {
            await ProcessFolderAsync(subFolder); // Rekursion für Unterordner
        }
    }
}
