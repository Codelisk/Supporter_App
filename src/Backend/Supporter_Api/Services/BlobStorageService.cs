using Azure;
using Azure.Storage.Blobs;
using Microsoft.Graph;

namespace Supporter_Api.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task UploadFiles(string containerName, string fileName, string fileContent)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(
                containerName
            );
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            var result = await blobClient.UploadAsync(BinaryData.FromString(fileContent), true);
        }
    }
}
