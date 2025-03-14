namespace Supporter_Api.Services
{
    public interface ICodeAnalyzeService
    {
        Task<string?> ChatAsync(string indexName, string systemMessage, string question);
    }
}
