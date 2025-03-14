namespace Supporter_Api.Services
{
    public interface ICodeAnalyzeService
    {
        Task<string?> ChatAsync(
            string indexName,
            string question,
            string assistantId,
            string threadId
        );
    }
}
