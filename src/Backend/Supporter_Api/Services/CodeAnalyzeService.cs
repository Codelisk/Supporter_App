using System.Text;
using System.Threading;
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
        AzureOpenAIClient azureOpenAIClient
    ) : ICodeAnalyzeService
    {
        public async Task<string?> ChatAsync(string question)
        {
            string loopPrompt =
                "You are an expert assistant that helps developers with their questions about Azure. "
                + "To answer a question or when creating searches or clarification questions, *only* use information provided by the documentation. "
                + "For every statement you make, you need to provide the source from the documentation. Each search result from the documentation has its file name as a prefix in square brackets. "
                + "If you can't find the answer, you can say 'I don't know' or 'I can't find the answer'."
                + "Write your answer in markdown. "
                + "If you see that search results are unrelated to the product the user is talking about, point that out and say you don't have good grounding data to answer.";

            var result = await ChatWithSearch(question, loopPrompt);
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

        private async Task<string> ChatWithSearch(string question, string? systemMessage = null)
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

                            var response = await searchService.QueryDocumentsAsync(query);

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
