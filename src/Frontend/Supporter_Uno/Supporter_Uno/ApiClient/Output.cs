// <auto-generated>
//     This code was generated by Refitter.
// </auto-generated>


using Refit;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable enable annotations

namespace Supporter_Dtos
{
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IAzureTopicMappingApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AzureTopicMapping/GetAllFull")]
        Task<object> GetAllFull();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/GetByTopicId")]
        Task<ICollection<AzureTopicMappingDto>> GetByTopicId([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AzureTopicMapping/GetFull")]
        Task<object> GetFull([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AzureTopicMapping/GetPaginated")]
        Task<object> GetPaginated([Query] string search, [Query] string searchField, [Query] int? page, [Query] int? perPage, [Query] string sortBy, [Query] string sortOrder, [Query] string filterBy, [Query] string filter);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AzureTopicMapping/DeleteAll")]
        Task<int> DeleteAll([Query] bool? areYouSure);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AzureTopicMapping/DeleteAllByRange")]
        Task<int> DeleteAllByRange([Body] IEnumerable<System.Guid> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/GetRange")]
        Task<ICollection<AzureTopicMappingDto>> GetRange([Query(CollectionFormat.Multi)] IEnumerable<System.Guid> ids);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/Count")]
        Task<int> Count();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/GetAll")]
        Task<ICollection<AzureTopicMappingDto>> GetAll();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/Get")]
        Task<AzureTopicMappingDto> Get([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AzureTopicMapping/Delete")]
        Task Delete([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AzureTopicMapping/AddRange")]
        Task AddRange([Body] IEnumerable<AzureTopicMappingDto> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AzureTopicMapping/Add")]
        Task<AzureTopicMappingDto> Add([Body] AzureTopicMappingDto body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AzureTopicMapping/GetLastOrDefault")]
        Task<AzureTopicMappingDto> GetLastOrDefault();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AzureTopicMapping/Save")]
        Task<AzureTopicMappingDto> Save([Body] AzureTopicMappingDto body);
    }

    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IAIFolderApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AIFolder/GetPaginated")]
        Task<object> GetPaginated([Query] string search, [Query] string searchField, [Query] int? page, [Query] int? perPage, [Query] string sortBy, [Query] string sortOrder, [Query] string filterBy, [Query] string filter);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AIFolder/DeleteAll")]
        Task<int> DeleteAll([Query] bool? areYouSure);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AIFolder/DeleteAllByRange")]
        Task<int> DeleteAllByRange([Body] IEnumerable<System.Guid> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AIFolder/GetRange")]
        Task<ICollection<AIFolderDto>> GetRange([Query(CollectionFormat.Multi)] IEnumerable<System.Guid> ids);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AIFolder/Count")]
        Task<int> Count();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AIFolder/GetAll")]
        Task<ICollection<AIFolderDto>> GetAll();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AIFolder/Get")]
        Task<AIFolderDto> Get([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AIFolder/Delete")]
        Task Delete([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AIFolder/AddRange")]
        Task AddRange([Body] IEnumerable<AIFolderDto> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AIFolder/Add")]
        Task<AIFolderDto> Add([Body] AIFolderDto body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AIFolder/GetLastOrDefault")]
        Task<AIFolderDto> GetLastOrDefault();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AIFolder/Save")]
        Task<AIFolderDto> Save([Body] AIFolderDto body);
    }

    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IAITopicApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AITopic/GetAllFull")]
        Task<object> GetAllFull();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/GetByFolderId")]
        Task<ICollection<AITopicDto>> GetByFolderId([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AITopic/GetFull")]
        Task<object> GetFull([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/AITopic/GetPaginated")]
        Task<object> GetPaginated([Query] string search, [Query] string searchField, [Query] int? page, [Query] int? perPage, [Query] string sortBy, [Query] string sortOrder, [Query] string filterBy, [Query] string filter);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AITopic/DeleteAll")]
        Task<int> DeleteAll([Query] bool? areYouSure);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AITopic/DeleteAllByRange")]
        Task<int> DeleteAllByRange([Body] IEnumerable<System.Guid> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/GetRange")]
        Task<ICollection<AITopicDto>> GetRange([Query(CollectionFormat.Multi)] IEnumerable<System.Guid> ids);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/Count")]
        Task<int> Count();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/GetAll")]
        Task<ICollection<AITopicDto>> GetAll();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/Get")]
        Task<AITopicDto> Get([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/AITopic/Delete")]
        Task Delete([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AITopic/AddRange")]
        Task AddRange([Body] IEnumerable<AITopicDto> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AITopic/Add")]
        Task<AITopicDto> Add([Body] AITopicDto body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/AITopic/GetLastOrDefault")]
        Task<AITopicDto> GetLastOrDefault();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/AITopic/Save")]
        Task<AITopicDto> Save([Body] AITopicDto body);
    }

    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IChatAnswerApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatAnswer/GetAllFull")]
        Task<object> GetAllFull();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/GetByQuestionId")]
        Task<ICollection<ChatAnswerDto>> GetByQuestionId([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatAnswer/GetFull")]
        Task<object> GetFull([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatAnswer/GetPaginated")]
        Task<object> GetPaginated([Query] string search, [Query] string searchField, [Query] int? page, [Query] int? perPage, [Query] string sortBy, [Query] string sortOrder, [Query] string filterBy, [Query] string filter);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatAnswer/DeleteAll")]
        Task<int> DeleteAll([Query] bool? areYouSure);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatAnswer/DeleteAllByRange")]
        Task<int> DeleteAllByRange([Body] IEnumerable<System.Guid> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/GetRange")]
        Task<ICollection<ChatAnswerDto>> GetRange([Query(CollectionFormat.Multi)] IEnumerable<System.Guid> ids);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/Count")]
        Task<int> Count();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/GetAll")]
        Task<ICollection<ChatAnswerDto>> GetAll();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/Get")]
        Task<ChatAnswerDto> Get([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatAnswer/Delete")]
        Task Delete([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatAnswer/AddRange")]
        Task AddRange([Body] IEnumerable<ChatAnswerDto> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatAnswer/Add")]
        Task<ChatAnswerDto> Add([Body] ChatAnswerDto body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatAnswer/GetLastOrDefault")]
        Task<ChatAnswerDto> GetLastOrDefault();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatAnswer/Save")]
        Task<ChatAnswerDto> Save([Body] ChatAnswerDto body);
    }

    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IChatQuestionApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatQuestion/GetAllFull")]
        Task<object> GetAllFull();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/GetByTopicId")]
        Task<ICollection<ChatQuestionDto>> GetByTopicId([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatQuestion/GetFull")]
        Task<object> GetFull([Query] System.Guid? id);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/api/ChatQuestion/GetPaginated")]
        Task<object> GetPaginated([Query] string search, [Query] string searchField, [Query] int? page, [Query] int? perPage, [Query] string sortBy, [Query] string sortOrder, [Query] string filterBy, [Query] string filter);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatQuestion/DeleteAll")]
        Task<int> DeleteAll([Query] bool? areYouSure);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatQuestion/DeleteAllByRange")]
        Task<int> DeleteAllByRange([Body] IEnumerable<System.Guid> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/GetRange")]
        Task<ICollection<ChatQuestionDto>> GetRange([Query(CollectionFormat.Multi)] IEnumerable<System.Guid> ids);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/Count")]
        Task<int> Count();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/GetAll")]
        Task<ICollection<ChatQuestionDto>> GetAll();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/Get")]
        Task<ChatQuestionDto> Get([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Delete("/api/ChatQuestion/Delete")]
        Task Delete([Query] System.Guid? id);

        /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatQuestion/AddRange")]
        Task AddRange([Body] IEnumerable<ChatQuestionDto> body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatQuestion/Add")]
        Task<ChatQuestionDto> Add([Body] ChatQuestionDto body);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Get("/api/ChatQuestion/GetLastOrDefault")]
        Task<ChatQuestionDto> GetLastOrDefault();

        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: application/json")]
        [Post("/api/ChatQuestion/Save")]
        Task<ChatQuestionDto> Save([Body] ChatQuestionDto body);
    }

    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.3.2.0")]
    public partial interface IWeatherForecastApi
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
        [Headers("Accept: text/plain, application/json, text/json")]
        [Get("/WeatherForecast")]
        Task<ICollection<WeatherForecast>> WeatherForecast();
    }


}