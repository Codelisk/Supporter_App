using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supporter_AI.Services.OpenAI.AzureAI
{
    using System;
    using System.ClientModel;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Azure;
    using Azure.AI.OpenAI;
    using global::OpenAI.Files;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    internal class AzureOpenAITrainService : IAzureOpenAITrainService
    {
        private readonly string _azureOpenAiEndpoint;
        private readonly string _azureOpenAiApiKey;
        private readonly string _blobStorageConnectionString;
        private readonly string _containerName;
        private readonly AzureOpenAIClient _openAIClient;
        private readonly ILogger<AzureOpenAITrainService> _logger;

        public AzureOpenAITrainService(
            IConfiguration configuration,
            ILogger<AzureOpenAITrainService> logger
        )
        {
            _logger = logger;
        }

        private async Task StartFineTuningAsync(string threadName, string text)
        {
            try
            {
                var fineTuningClient = _openAIClient.GetFineTuningClient();
                var fileClient = _openAIClient.GetOpenAIFileClient();
                fileClient.UploadFileAsync("", FileUploadPurpose.FineTune);

                var byteArray = Encoding.UTF8.GetBytes(text);
                var fineTuningJob = await fineTuningClient.CreateFineTuningJobAsync(
                    BinaryContent.Create(new BinaryData("")),
                    true
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Starten des Fine-Tunings.");
            }
        }
    }
}
