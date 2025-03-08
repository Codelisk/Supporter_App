using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Octokit;
using Supporter_Dtos;
using Supporter_Uno.Common;
using Supporter_Uno.Providers;

namespace Supporter_Uno.Presentation.CodeAnalysis.Analyze;

internal partial class RepoAnalyzePageViewModel : BasePageViewModel
{
    public RepoAnalyzePageViewModel(
        BaseVmServices baseVmServices,
        ILogger<RepoAnalyzePageViewModel> logger,
        IConfiguration configuration,
        IAzureRepoMappingApi azureRepoMappingApi,
        IAIRepoApi aIRepoApi,
        IAIApi aIApi
    )
        : base(baseVmServices)
    {
        this.logger = logger;
        this.configuration = configuration;
        this.azureRepoMappingApi = azureRepoMappingApi;
        this.aIRepoApi = aIRepoApi;
        this.aIApi = aIApi;
    }

    AIRepoDto repo;
    AzureRepoMappingDto azureRepoMappingDto;
    private readonly ILogger<RepoAnalyzePageViewModel> logger;
    private readonly IConfiguration configuration;
    private readonly IAzureRepoMappingApi azureRepoMappingApi;
    private readonly IAIRepoApi aIRepoApi;
    private readonly IAIApi aIApi;

    public override async void Initialize(NavigationEventArgs e)
    {
        base.Initialize(e);

        this.azureRepoMappingDto = e.Parameter as AzureRepoMappingDto;
        this.repo = await aIRepoApi.Get(azureRepoMappingDto.RepoId);
    }

    private void ShowMessage(string message)
    {
        logger.LogInformation(message);
    }

    [RelayCommand]
    public async Task Analyze()
    {
        if (repo == null || string.IsNullOrEmpty(repo.Owner) || string.IsNullOrEmpty(repo.Name))
        {
            ShowMessage("Ungültiges Repository.");
            return;
        }

        try
        {
            string githubToken = configuration["GitHub:Token"];
            var client = new GitHubClient(new ProductHeaderValue("SupporterApp"));
            client.Credentials = new Credentials(githubToken, AuthenticationType.Bearer);
            // Liste aller Dateien abrufen
            var files = await GetAllFilesFromRepo(client, repo.Owner, repo.Name);

            if (files.Count == 0)
            {
                ShowMessage("Keine Dateien im Repository gefunden.");
                return;
            }

            ShowMessage($"Gefundene Dateien: {files.Count}");

            // Hier könnte eine AI-Analyse erfolgen
            foreach (var file in files)
            {
                var content = await GetFileContent(client, repo.Owner, repo.Name, file);
                var analysisResult = await AnalyzeCodeWithAI(repo.Name, repo.Owner, file, content);
                ShowMessage($"Analyse für {file}:\n{analysisResult}");
            }

            ShowMessage("Analyse abgeschlossen.");
        }
        catch (Exception ex)
        {
            ShowMessage($"Fehler bei der Analyse: {ex.Message}");
        }
    }

    private async Task<List<string>> GetAllFilesFromRepo(
        GitHubClient client,
        string owner,
        string repo,
        string path = "src"
    )
    {
        var files = new List<string>();
        var rateLimits = await client.RateLimit.GetRateLimits();
        if (rateLimits.Rate.Remaining < 2000)
        {
            return files;
        }
        var contents = await client.Repository.Content.GetAllContents(owner, repo, path);
        foreach (var content in contents)
        {
            if (content.Type == ContentType.File)
            {
                files.Add(content.Path);
            }
            else if (content.Type == ContentType.Dir)
            {
                var subFiles = await GetAllFilesFromRepo(client, owner, repo, content.Path);
                files.AddRange(subFiles);
            }
        }

        return files;
    }

    private async Task<string> GetFileContent(
        GitHubClient client,
        string owner,
        string repo,
        string filePath
    )
    {
        var fileContent = await client.Repository.Content.GetAllContents(owner, repo, filePath);
        return fileContent[0].Content;
    }

    private async Task<string> AnalyzeCodeWithAI(
        string repoName,
        string repoOwner,
        string file,
        string code
    )
    {
        return await aIApi.Chat(
            $"Merk dir das File ({file} im Github Repository {repoName} für den Owner {repoOwner})\n\n{code}",
            azureRepoMappingDto.ThreadId,
            azureRepoMappingDto.AssistantId,
            null
        );
    }
}
