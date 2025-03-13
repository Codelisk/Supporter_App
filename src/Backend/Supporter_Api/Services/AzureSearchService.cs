using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Supporter_Api.Enums;
using Supporter_Api.Models;

namespace Supporter_Api.Services
{
    public class AzureSearchService(SearchClient searchClient) : ISearchService
    {
        public async Task<SupportingContentRecord[]> QueryDocumentsAsync(string? query = null)
        {
            var searchResultResponse = await searchClient.SearchAsync<SearchDocument>(
                query,
                new SearchOptions
                {
                    Select = { "title", "chunk" },
                    VectorSearch = new VectorSearchOptions()
                    {
                        Queries =
                        {
                            new VectorizableTextQuery(query)
                            {
                                KNearestNeighborsCount = 50,
                                Fields = { "text_vector" },
                            },
                        },
                    },
                }
            );
            if (searchResultResponse.Value is null)
            {
                throw new InvalidOperationException("fail to get search result");
            }

            SearchResults<SearchDocument> searchResult = searchResultResponse.Value;

            // Assemble sources here.
            // Example output for each SearchDocument:
            // {
            //   "@search.score": 11.65396,
            //   "id": "Northwind_Standard_Benefits_Details_pdf-60",
            //   "content": "x-ray, lab, or imaging service, you will likely be responsible for paying a copayment or coinsurance. The exact amount you will be required to pay will depend on the type of service you receive. You can use the Northwind app or website to look up the cost of a particular service before you receive it.\nIn some cases, the Northwind Standard plan may exclude certain diagnostic x-ray, lab, and imaging services. For example, the plan does not cover any services related to cosmetic treatments or procedures. Additionally, the plan does not cover any services for which no diagnosis is provided.\nIt’s important to note that the Northwind Standard plan does not cover any services related to emergency care. This includes diagnostic x-ray, lab, and imaging services that are needed to diagnose an emergency condition. If you have an emergency condition, you will need to seek care at an emergency room or urgent care facility.\nFinally, if you receive diagnostic x-ray, lab, or imaging services from an out-of-network provider, you may be required to pay the full cost of the service. To ensure that you are receiving services from an in-network provider, you can use the Northwind provider search ",
            //   "category": null,
            //   "sourcepage": "Northwind_Standard_Benefits_Details-24.pdf",
            //   "sourcefile": "Northwind_Standard_Benefits_Details.pdf"
            // }
            var sb = new List<SupportingContentRecord>();
            foreach (var doc in searchResult.GetResults())
            {
                doc.Document.TryGetValue("title", out var sourcePageValue);
                string? contentValue;
                try
                {
                    doc.Document.TryGetValue("chunk", out var value);
                    contentValue = (string)value;
                }
                catch (ArgumentNullException)
                {
                    contentValue = null;
                }

                if (sourcePageValue is string sourcePage && contentValue is string content)
                {
                    content = content.Replace('\r', ' ').Replace('\n', ' ');
                    sb.Add(new SupportingContentRecord(sourcePage, content));
                }
            }

            return [.. sb];
        }
    }
}
