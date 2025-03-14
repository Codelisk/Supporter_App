using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supporter_Api.Services;

namespace Supporter_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AzureADUsers")]
    [Authorize(Policy = "ApiKeyUsers")]
    public class AzureBlobController(IBlobStorageService blobStorageService) : ControllerBase
    {
        [HttpGet("UploadFiles")]
        public async Task<IActionResult> UploadFiles(
            string containerName,
            string fileName,
            string fileContent
        )
        {
            await blobStorageService.UploadFiles(containerName, fileName, fileContent);
            return Ok();
        }
    }
}
