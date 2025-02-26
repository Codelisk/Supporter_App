using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Files;
using Supporter_AI.Constants;

namespace Supporter_AI.Services.OpenAI.AzureAI
{
    internal class AzureOpenAIChatService : IAzureOpenAIChatService
    {
        private readonly AzureOpenAIClient _client;
        private readonly AssistantClient _assistantClient;
        private readonly ChatClient _chatClient;
        private readonly OpenAIFileClient _openAIFileClient;

        public AzureOpenAIChatService(AzureOpenAIClient azureOpenAIClient)
        {
            _client = azureOpenAIClient;
            _assistantClient = _client.GetAssistantClient();
            _chatClient = _client.GetChatClient(AzureConstants.DefaultModel);
            _openAIFileClient = _client.GetOpenAIFileClient();
        }

        public Task<ClientResult<Assistant>> CreateAssistant(string name, int temperature)
        {
            return _assistantClient.CreateAssistantAsync(
                AzureConstants.DefaultModel,
                new AssistantCreationOptions { Name = name, Temperature = temperature }
            );
        }

        public Task<ClientResult<AssistantThread>> CreateThreadAsync(string threadId)
        {
            return _assistantClient.CreateThreadAsync();
        }

        public Task<ClientResult<ThreadRun>> CreateRunAsync(
            string threadId,
            string assistantId,
            float? temp
        )
        {
            return _assistantClient.CreateRunAsync(
                threadId,
                assistantId,
                new RunCreationOptions { Temperature = temp }
            );
        }

        public async Task<string> Chat(
            string question,
            string threadId,
            string assistantId,
            float? temperature
        )
        {
            var chatMessage = await _assistantClient.CreateMessageAsync(
                threadId,
                MessageRole.User,
                new List<MessageContent> { MessageContent.FromText(question) }
            );

            var runResponse = await _assistantClient.CreateRunAsync(threadId, assistantId);
            ClientResult<ThreadRun> threadRun = null;
            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                threadRun = await _assistantClient.GetRunAsync(threadId, runResponse.Value.Id);
            } while (!threadRun.Value.Status.IsTerminal);

            // Finally, we'll print out the full history for the thread that includes the augmented generation
            AsyncCollectionResult<ThreadMessage> messages = _assistantClient.GetMessagesAsync(
                threadId,
                new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending }
            );

            string result = "";
            await foreach (ThreadMessage message in messages)
            {
                result = ($"[{message.Role.ToString().ToUpper()}]: ");
                foreach (MessageContent contentItem in message.Content)
                {
                    if (!string.IsNullOrEmpty(contentItem.Text))
                    {
                        result = ($"{contentItem.Text}");

                        if (contentItem.TextAnnotations.Count > 0)
                        {
                            result += "\n";
                        }

                        // Include annotations, if any.
                        foreach (TextAnnotation annotation in contentItem.TextAnnotations)
                        {
                            if (!string.IsNullOrEmpty(annotation.InputFileId))
                            {
                                result = ($"* File citation, file ID: {annotation.InputFileId}");
                            }
                            if (!string.IsNullOrEmpty(annotation.OutputFileId))
                            {
                                result = ($"* File output, new file ID: {annotation.OutputFileId}");
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(contentItem.ImageFileId))
                    {
                        var imageInfo = await _openAIFileClient.GetFileAsync(
                            contentItem.ImageFileId
                        );
                        BinaryData imageBytes = await _openAIFileClient.DownloadFileAsync(
                            contentItem.ImageFileId
                        );
                        using FileStream stream = File.OpenWrite($"{imageInfo.Value.Filename}.png");
                        imageBytes.ToStream().CopyTo(stream);

                        result = ($"<image: {imageInfo.Value.Filename}.png>");
                    }
                }
                result += "\n";
            }

            return result;
        }

        public async Task<string> Chat(string question)
        {
            ChatClient chatClient = _client.GetChatClient("gpt-4o-mini");

            var chatResult = await chatClient.CompleteChatAsync(
                new ChatMessage[] { new UserChatMessage(question) }
            );

            string result = string.Empty;
            foreach (var item in chatResult.Value.Content)
            {
                result += string.Join('\n', result);
            }
            return result;
        }
    }
}
