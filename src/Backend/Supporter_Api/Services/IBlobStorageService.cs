namespace Supporter_Api.Services
{
    public interface IBlobStorageService
    {
        Task UploadFiles(string containerName, string fileName, string fileContent);
    }
}
