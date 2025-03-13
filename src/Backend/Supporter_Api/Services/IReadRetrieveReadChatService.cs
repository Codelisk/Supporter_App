namespace Supporter_Api.Services
{
    public interface IReadRetrieveReadChatService
    {
        Task<string?> ChatAsync(string question);
    }
}
