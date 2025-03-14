using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Supporter_Api.Models;

namespace Supporter_Api.Services
{
    public interface ISearchService
    {
        Task<SupportingContentRecord[]> QueryDocumentsAsync(string indexName, string? query = null);
    }
}
