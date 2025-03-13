using Microsoft.AspNetCore.Mvc;
using Supporter_Api.Services;

namespace Supporter_Api.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IReadRetrieveReadChatService readRetrieveReadChatService;

        public TestController(IReadRetrieveReadChatService readRetrieveReadChatService)
        {
            this.readRetrieveReadChatService = readRetrieveReadChatService;
        }

        [HttpGet("Test")]
        public async Task<string> Test()
        {
            return await readRetrieveReadChatService.ChatAsync(
                "Does any file use the objectprovider?"
            );
        }
    }
}
