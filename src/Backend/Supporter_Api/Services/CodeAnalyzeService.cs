using System.ClientModel;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure;
using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using Azure.Search.Documents;
using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Files;
using Supporter_AI.Extensions;
using Supporter_AI.Services.OpenAI.AzureAI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Supporter_Api.Services
{
    public class CodeAnalyzeService(
        ISearchService searchService,
        IAzureOpenAIChatService azureOpenAIChatService,
        IConfiguration configuration,
        AzureOpenAIClient azureOpenAIClient
    ) : ICodeAnalyzeService
    {
        public async Task<string?> ChatAsync(
            string indexName,
            string question,
            string assistantId,
            string threadId
        )
        {
            var result = await ChatWithSearch(indexName, question, assistantId, threadId);
            return result;
        }
#pragma warning disable OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        async Task<ToolOutput> GetResolvedToolOutput(
            RequiredAction toolCall,
            string indexName,
            string query
        )
        {
            if (toolCall.FunctionName.Equals("search"))
            {
                var response = await searchService.QueryDocumentsAsync(indexName, query: query);
                return new ToolOutput(
                    toolCall.ToolCallId,
                    string.Join(
                        "-----------------",
                        response
                            .Select(x => "Filename" + x.Title + "\nContent:" + x.Content)
                            .ToList()
                    )
                );
            }
            return null;
        }

        public async Task<string> ChatWithSearch(
            string indexName,
            string question,
            string assistantId,
            string threadId
        )
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();
            chatMessages.Add(new UserChatMessage(question));
            var _assistantClient = azureOpenAIChatService.GetChatClient();
            foreach (var item in chatMessages)
            {
                await _assistantClient.CreateMessageAsync(
                    threadId,
                    item.GetRole(),
                    item.Content.ToMessageContent()
                );
            }

            var runResponse = await _assistantClient.CreateRunAsync(threadId, assistantId);
            ClientResult<ThreadRun> threadRun = null;
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                threadRun = await _assistantClient.GetRunAsync(threadId, runResponse.Value.Id);

                if (threadRun.Value.Status == RunStatus.RequiresAction)
                {
                    List<ToolOutput> toolOutputs = new();
                    foreach (var toolCall in threadRun.Value.RequiredActions)
                    {
                        toolOutputs.Add(await GetResolvedToolOutput(toolCall, indexName, question));
                    }
                    runResponse = await _assistantClient.SubmitToolOutputsToRunAsync(
                        threadId,
                        threadRun.Value.Id,
                        toolOutputs
                    );
                }
            } while (threadRun.Value.Status == RunStatus.RequiresAction);

            // Finally, we'll print out the full history for the thread that includes the augmented generation
            AsyncCollectionResult<ThreadMessage> messages = _assistantClient.GetMessagesAsync(
                threadId,
                new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending }
            );

            do
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5));
                threadRun = await _assistantClient.GetRunAsync(threadId, runResponse.Value.Id);

                if (threadRun.Value.Status == RunStatus.RequiresAction)
                {
                    List<ToolOutput> toolOutputs = new();
                    foreach (var toolCall in threadRun.Value.RequiredActions)
                    {
                        toolOutputs.Add(await GetResolvedToolOutput(toolCall, indexName, question));
                    }
                    runResponse = await _assistantClient.SubmitToolOutputsToRunAsync(
                        threadId,
                        threadRun.Value.Id,
                        toolOutputs
                    );
                }
            } while (!threadRun.Value.Status.IsTerminal);

            messages = _assistantClient.GetMessagesAsync(
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
                    }
                }
                result += "\n";
            }
            return result;
        }
#pragma warning restore OPENAI001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }
}
