﻿using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using Supporter_AI.Constants;

namespace Supporter_AI.Services.OpenAI.AzureAI
{
    internal class AzureOpenAIChatService : IAzureOpenAIChatService
    {
        private readonly AzureOpenAIClient _client;
        private readonly AssistantClient _assistantClient;
        private readonly ChatClient _chatClient;

        public AzureOpenAIChatService(AzureOpenAIClient azureOpenAIClient)
        {
            _client = azureOpenAIClient;
            _assistantClient = _client.GetAssistantClient();
            _chatClient = _client.GetChatClient(AzureConstants.DefaultModel);
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

        public async Task<ClientResult<ThreadRun>> Chat(
            string question,
            string threadId,
            string assistantId,
            float? temperature
        )
        {
            var message = await _assistantClient.CreateMessageAsync(
                threadId,
                MessageRole.User,
                new List<MessageContent> { MessageContent.FromText(question) }
            );

            var runResult = await _assistantClient.CreateRunAsync(threadId, assistantId);
            _assistantClient.Run
            return runResult;
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
