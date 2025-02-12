using Supporter_AI.Services.OpenAI.AzureAI;

namespace Supporter_AI_Tests
{
    public class UnitTest1
    {
        private readonly IAzureOpenAIChatService azureOpenAIService;

        public UnitTest1(IAzureOpenAIChatService azureOpenAIService = null)
        {
            this.azureOpenAIService = azureOpenAIService;
        }

        [Fact]
        public async Task Test1()
        {
            await azureOpenAIService.Chat("Hi");
        }
    }
}
