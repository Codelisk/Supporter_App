using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Supporer_Shared.Models.AI;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Extensions;
using Supporter_Uno.Providers;
using Windows.Storage.Pickers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Analyze;

internal partial class FileRepoAnalyzePageViewModel : BasePageViewModel
{
    public FileRepoAnalyzePageViewModel(
        BaseVmServices baseVmServices,
        IAIApi aIApi,
        ILogger<FileRepoAnalyzePageViewModel> logger
    )
        : base(baseVmServices)
    {
        this.aIApi = aIApi;
        this.logger = logger;
    }

    [RelayCommand]
    public async Task PickFolder()
    {
        var picker = new FolderPicker();
        picker.FileTypeFilter.Add("*"); // Erforderlich für UWP-Apps

        // Get the current window's HWND by passing a Window object
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle((App.Current as App).MainWindow);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        var folder = await picker.PickSingleFolderAsync();
        if (folder != null)
        {
            this.IsBusy = true;
            try
            {
                await ProcessFolderAsync(folder);

                await OnAddTrainingAsync(
                    string.Join(
                        "---------------------------------------------------------",
                        Contents
                    )
                );
            }
            finally
            {
                this.IsBusy = false;
                await this.Navigator.GoBack(this);
            }
        }
    }

    List<string> Contents = new();
    private readonly IAIApi aIApi;

    private async Task ProcessFolderAsync(StorageFolder folder)
    {
        var files = await folder.GetFilesAsync();
        var subFolders = await folder.GetFoldersAsync();

        foreach (var file in files)
        {
            try
            {
                string content = await FileIO.ReadTextAsync(file);
                Contents.Add($"File: {file.Name}\nContent: {content}");
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

    AIRepoDto repo;
    AzureRepoMappingDto azureRepoMappingDto;
    private readonly ILogger<FileRepoAnalyzePageViewModel> logger;
    private readonly IConfiguration configuration;
    private readonly IAzureRepoMappingApi azureRepoMappingApi;
    private readonly IAIRepoApi aIRepoApi;

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        this.azureRepoMappingDto = e.Parameter as AzureRepoMappingDto;
    }

    private async Task OnAddTrainingAsync(string text)
    {
        const int maxLength = 15000;
        var trainingTexts = text.SplitText(maxLength);
        string prefix = "Merk dir das für die Zukunft:\n\n";

        foreach (var textPart in trainingTexts)
        {
            try
            {
                var answer = await aIApi.Chat(
                    new ChatPayload(
                        prefix + textPart,
                        azureRepoMappingDto.ThreadId,
                        azureRepoMappingDto.AssistantId,
                        null
                    )
                );
                prefix = "\n\nSo geht’s weiter \n\n";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while adding training");
                //Something went wrong
            }
        }
    }
}
