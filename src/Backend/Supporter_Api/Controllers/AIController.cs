using System.ClientModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Assistants;
using Supporter_AI.Models;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Api.Models;

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

        [HttpGet("GetSettings")]
        public async Task<AISettings> GetSettings(string assistantId)
        {
            var client = azureOpenAIChatService.GetChatClient();
            var assistant = await client.GetAssistantAsync(assistantId);
            return new AISettings(
                assistant.Value.Model,
                assistant.Value.Description,
                assistant.Value.Instructions,
                assistant.Value.Temperature,
                assistant.Value.NucleusSamplingFactor
            );
        }

        [Produces("text/markdown")]
        [Microsoft.AspNetCore.Mvc.HttpPost("Chat")]
        public async Task<ActionResult<string>> Chat(ChatPayload chatPayload)
        {
            var result = await azureOpenAIChatService.Chat(
                chatPayload.question,
                chatPayload.threadId,
                chatPayload.assistantId,
                chatPayload.temperature
            );
            return Content(result);
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
