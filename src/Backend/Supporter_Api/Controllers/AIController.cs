using System.ClientModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Assistants;
using Supporter_AI.Services.OpenAI.AzureAI;

namespace Supporter_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(Policy = "AzureADUsers")]
    [Authorize(Policy = "ApiKeyUsers")]
    public class AIController : ControllerBase
    {
        private readonly IAzureOpenAIChatService azureOpenAIChatService;

        public AIController(IAzureOpenAIChatService azureOpenAIChatService)
        {
            this.azureOpenAIChatService = azureOpenAIChatService;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("Chat")]
        public Task<string> Chat(
            string question,
            string threadId,
            string assistantId,
            float? temperature
        )
        {
            return azureOpenAIChatService.Chat(question, threadId, assistantId, temperature);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("CreateAssistant")]
        public async Task<string> CreateAssistant(string name, int temperature)
        {
            var result = await azureOpenAIChatService.CreateAssistant(name, temperature);
            return result.Value.Id;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("EditAssistant")]
        public async Task<string> EditAssistant(
            string assistantId,
            float? temperature = null,
            float? nucleusSamplingFactor = null,
            string? model = null,
            string? instructions = null,
            string? description = null
        )
        {
            var result = await azureOpenAIChatService.EditAssistant(
                assistantId,
                temperature,
                nucleusSamplingFactor,
                model,
                instructions,
                description
            );
            return result.Value.Id;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("CreateThreadAsync")]
        public async Task<string> CreateThreadAsync(string threadId)
        {
            var result = await azureOpenAIChatService.CreateThreadAsync(threadId);
            return result.Value.Id;
        }
    }
}
