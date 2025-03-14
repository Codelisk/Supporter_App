using System.Text;
using System.Threading;
using Azure;
using Azure.AI.OpenAI;
using Azure.AI.OpenAI.Chat;
using Azure.Search.Documents;
using OpenAI.Chat;
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
            string systemMessage,
            string question
        )
        {
            var result = await ChatWithSearch(indexName, question, systemMessage);
            return result;
        }

        private ChatTool GetSearchTool()
        {
            string parameters =
                @"
{
    ""type"": ""object"",
    ""properties"": {
        ""query"": {
            ""type"": ""string"",
            ""description"": ""The search query to use for the documentation. Generate this based on the chat history, with focus on the last user question, and your own analysis of what to search""
        }
    },
    ""required"": [""query""],
    ""additionalProperties"": false
}";
            var chatTool = ChatTool.CreateFunctionTool(
                "search",
                "Search the documentation to find the right data to answer the last question in this conversation.",
                BinaryData.FromBytes(Encoding.UTF8.GetBytes(parameters))
            );

            return chatTool;
        }

        private async Task<string> ChatWithSearch(
            string indexName,
            string question,
            string? systemMessage = null
        )
        {
            ChatClient chatClient = azureOpenAIClient.GetChatClient("gpt-4o");

            List<ChatMessage> chatMessages = new List<ChatMessage>();
            if (systemMessage is not null)
            {
                chatMessages.Add(new SystemChatMessage(systemMessage));
            }
            chatMessages.Add(new UserChatMessage(question));

            string result = string.Empty;
            while (true)
            {
                var chatResult = await chatClient.CompleteChatAsync(
                    chatMessages,
                    new ChatCompletionOptions()
                    {
                        Tools = { GetSearchTool() },
                        AllowParallelToolCalls = false,
                    }
                );
                if (chatResult.Value.FinishReason == ChatFinishReason.ToolCalls)
                {
                    foreach (var call in chatResult.Value.ToolCalls)
                    {
                        if (call.FunctionName == "search")
                        {
                            string query = call.FunctionArguments.ToString();

                            var response = await searchService.QueryDocumentsAsync(
                                indexName,
                                query: query
                            );

                            chatMessages.Add(
                                new AssistantChatMessage(
                                    new List<ChatToolCall>
                                    {
                                        ChatToolCall.CreateFunctionToolCall(
                                            call.Id,
                                            call.FunctionName,
                                            call.FunctionArguments
                                        ),
                                    }
                                )
                            );
                            chatMessages.Add(
                                ChatMessage.CreateToolMessage(
                                    call.Id,
                                    string.Join(
                                        "\n\n",
                                        response.Select(x =>
                                            "Filename" + x.Title + "\nContent:" + x.Content
                                        )
                                    )
                                )
                            );
                        }
                    }
                }
                else
                {
                    var message = chatResult.Value.Content[0].Text;
                    result += string.Join('\n', message);
                    break;
                }
            }

            return result;
        }
    }
}
