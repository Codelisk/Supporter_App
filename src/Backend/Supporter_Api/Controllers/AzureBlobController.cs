using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supporer_Shared.Models.Azure;
using Supporter_Api.Models;
using Supporter_Api.Services;

namespace Supporter_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AzureADUsers")]
    [Authorize(Policy = "ApiKeyUsers")]
    public class AzureBlobController(IBlobStorageService blobStorageService) : ControllerBase
    {
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromBody] UploadFilePayload uploadFilePayload)
        {
            await blobStorageService.UploadFiles(
                uploadFilePayload.containerName,
                uploadFilePayload.fileName,
                uploadFilePayload.fileContent
            );
            return Ok();
        }
    }
}
