using Microsoft.AspNetCore.Mvc;
using Supporter_Api.Services;

namespace Supporter_Api.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICodeAnalyzeService readRetrieveReadChatService;

        public TestController(ICodeAnalyzeService readRetrieveReadChatService)
        {
            this.readRetrieveReadChatService = readRetrieveReadChatService;
        }

        [HttpGet("Test")]
        public async Task<string> Test()
        {
            return await readRetrieveReadChatService.ChatAsync(
                "Make top 2 performant improvements for the code"
            );
        }
    }
}
