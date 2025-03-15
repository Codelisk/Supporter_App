using System.ClientModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Assistants;
using Supporer_Shared.Models.AI;
using Supporter_AI.Models;
using Supporter_AI.Services.OpenAI.AzureAI;
using Supporter_Api.Models;
using Supporter_Api.Services;

namespace Supporter_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("text/plain")]
    [Authorize(Policy = "AzureADUsers")]
    [Authorize(Policy = "ApiKeyUsers")]
    public class AIController : ControllerBase
    {
        private readonly IAzureOpenAIChatService azureOpenAIChatService;
        private readonly ICodeAnalyzeService codeAnalyzeService;

        public AIController(
            IAzureOpenAIChatService azureOpenAIChatService,
            ICodeAnalyzeService codeAnalyzeService
        )
        {
            this.azureOpenAIChatService = azureOpenAIChatService;
            this.codeAnalyzeService = codeAnalyzeService;
        }

        [Produces("text/markdown")]
        [HttpGet("ChatWithSearch")]
        public async Task<ActionResult<string>> Chat(
            string indexName,
            string question,
            string assistantId,
            string threadId
        )
        {
            return Content(
                await codeAnalyzeService.ChatAsync(indexName, question, assistantId, threadId)
            );
        }

        [Produces("application/json")]
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
        public async Task<ActionResult<string>> Chat([FromBody] ChatPayload chatPayload)
        {
            var result = await azureOpenAIChatService.Chat(
                chatPayload.question,
                chatPayload.threadId,
                chatPayload.assistantId,
                chatPayload.temperature
            );
            return Content(result);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("CreateAssistant")]
        public async Task<string> CreateAssistant(
            [FromBody] CreateAssistantsPayload createAssistantsPayload
        )
        {
            var result = await azureOpenAIChatService.CreateAssistant(
                createAssistantsPayload.name,
                createAssistantsPayload.temperature,
                createAssistantsPayload.isFileSearch,
                createAssistantsPayload.isCodeInterpreter,
                createAssistantsPayload.instructions
            );
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
        public async Task<string> CreateThreadAsync(bool useFile, bool useCodeInterpreter)
        {
            var result = await azureOpenAIChatService.CreateThreadAsync(
                useFile,
                useCodeInterpreter
            );
            return result.Value.Id;
        }
    }
}
