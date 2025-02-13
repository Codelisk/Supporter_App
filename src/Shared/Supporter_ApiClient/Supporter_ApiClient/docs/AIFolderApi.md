# Org.OpenAPITools.Api.AIFolderApi

All URIs are relative to *https://localhost:7209*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAIFolderAddPost**](AIFolderApi.md#apiaifolderaddpost) | **POST** /api/AIFolder/Add |  |
| [**ApiAIFolderAddRangePost**](AIFolderApi.md#apiaifolderaddrangepost) | **POST** /api/AIFolder/AddRange |  |
| [**ApiAIFolderCountGet**](AIFolderApi.md#apiaifoldercountget) | **GET** /api/AIFolder/Count |  |
| [**ApiAIFolderDeleteAllByRangeDelete**](AIFolderApi.md#apiaifolderdeleteallbyrangedelete) | **DELETE** /api/AIFolder/DeleteAllByRange |  |
| [**ApiAIFolderDeleteAllDelete**](AIFolderApi.md#apiaifolderdeletealldelete) | **DELETE** /api/AIFolder/DeleteAll |  |
| [**ApiAIFolderDeleteDelete**](AIFolderApi.md#apiaifolderdeletedelete) | **DELETE** /api/AIFolder/Delete |  |
| [**ApiAIFolderGetAllGet**](AIFolderApi.md#apiaifoldergetallget) | **GET** /api/AIFolder/GetAll |  |
| [**ApiAIFolderGetGet**](AIFolderApi.md#apiaifoldergetget) | **GET** /api/AIFolder/Get |  |
| [**ApiAIFolderGetLastOrDefaultGet**](AIFolderApi.md#apiaifoldergetlastordefaultget) | **GET** /api/AIFolder/GetLastOrDefault |  |
| [**ApiAIFolderGetPaginatedGet**](AIFolderApi.md#apiaifoldergetpaginatedget) | **GET** /api/AIFolder/GetPaginated |  |
| [**ApiAIFolderGetRangeGet**](AIFolderApi.md#apiaifoldergetrangeget) | **GET** /api/AIFolder/GetRange |  |
| [**ApiAIFolderSavePost**](AIFolderApi.md#apiaifoldersavepost) | **POST** /api/AIFolder/Save |  |

<a id="apiaifolderaddpost"></a>
# **ApiAIFolderAddPost**
> AIFolderDto ApiAIFolderAddPost (AIFolderDto aIFolderDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderAddPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var aIFolderDto = new AIFolderDto(); // AIFolderDto | 

            try
            {
                AIFolderDto result = apiInstance.ApiAIFolderAddPost(aIFolderDto);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderAddPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderAddPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AIFolderDto> response = apiInstance.ApiAIFolderAddPostWithHttpInfo(aIFolderDto);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderAddPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aIFolderDto** | [**AIFolderDto**](AIFolderDto.md) |  |  |

### Return type

[**AIFolderDto**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifolderaddrangepost"></a>
# **ApiAIFolderAddRangePost**
> void ApiAIFolderAddRangePost (List<AIFolderDto> aIFolderDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderAddRangePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var aIFolderDto = new List<AIFolderDto>(); // List<AIFolderDto> | 

            try
            {
                apiInstance.ApiAIFolderAddRangePost(aIFolderDto);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderAddRangePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderAddRangePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAIFolderAddRangePostWithHttpInfo(aIFolderDto);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderAddRangePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aIFolderDto** | [**List&lt;AIFolderDto&gt;**](AIFolderDto.md) |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldercountget"></a>
# **ApiAIFolderCountGet**
> int ApiAIFolderCountGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderCountGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);

            try
            {
                int result = apiInstance.ApiAIFolderCountGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderCountGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderCountGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAIFolderCountGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderCountGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**int**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifolderdeleteallbyrangedelete"></a>
# **ApiAIFolderDeleteAllByRangeDelete**
> int ApiAIFolderDeleteAllByRangeDelete (List<Guid> requestBody)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderDeleteAllByRangeDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var requestBody = new List<Guid>(); // List<Guid> | 

            try
            {
                int result = apiInstance.ApiAIFolderDeleteAllByRangeDelete(requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteAllByRangeDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderDeleteAllByRangeDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAIFolderDeleteAllByRangeDeleteWithHttpInfo(requestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteAllByRangeDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **requestBody** | [**List&lt;Guid&gt;**](Guid.md) |  |  |

### Return type

**int**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifolderdeletealldelete"></a>
# **ApiAIFolderDeleteAllDelete**
> int ApiAIFolderDeleteAllDelete (bool? areYouSure = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderDeleteAllDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var areYouSure = true;  // bool? |  (optional) 

            try
            {
                int result = apiInstance.ApiAIFolderDeleteAllDelete(areYouSure);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteAllDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderDeleteAllDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAIFolderDeleteAllDeleteWithHttpInfo(areYouSure);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteAllDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **areYouSure** | **bool?** |  | [optional]  |

### Return type

**int**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifolderdeletedelete"></a>
# **ApiAIFolderDeleteDelete**
> void ApiAIFolderDeleteDelete (Guid? id = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderDeleteDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var id = "id_example";  // Guid? |  (optional) 

            try
            {
                apiInstance.ApiAIFolderDeleteDelete(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderDeleteDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAIFolderDeleteDeleteWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderDeleteDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid?** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldergetallget"></a>
# **ApiAIFolderGetAllGet**
> List&lt;AIFolderDto&gt; ApiAIFolderGetAllGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderGetAllGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);

            try
            {
                List<AIFolderDto> result = apiInstance.ApiAIFolderGetAllGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetAllGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderGetAllGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<AIFolderDto>> response = apiInstance.ApiAIFolderGetAllGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetAllGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;AIFolderDto&gt;**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldergetget"></a>
# **ApiAIFolderGetGet**
> AIFolderDto ApiAIFolderGetGet (Guid? id = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderGetGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var id = "id_example";  // Guid? |  (optional) 

            try
            {
                AIFolderDto result = apiInstance.ApiAIFolderGetGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderGetGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AIFolderDto> response = apiInstance.ApiAIFolderGetGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid?** |  | [optional]  |

### Return type

[**AIFolderDto**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldergetlastordefaultget"></a>
# **ApiAIFolderGetLastOrDefaultGet**
> AIFolderDto ApiAIFolderGetLastOrDefaultGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderGetLastOrDefaultGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);

            try
            {
                AIFolderDto result = apiInstance.ApiAIFolderGetLastOrDefaultGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetLastOrDefaultGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderGetLastOrDefaultGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AIFolderDto> response = apiInstance.ApiAIFolderGetLastOrDefaultGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetLastOrDefaultGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**AIFolderDto**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldergetpaginatedget"></a>
# **ApiAIFolderGetPaginatedGet**
> void ApiAIFolderGetPaginatedGet (string? search = null, string? searchField = null, int? page = null, int? perPage = null, string? sortBy = null, string? sortOrder = null, string? filterBy = null, string? filter = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderGetPaginatedGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var search = "search_example";  // string? |  (optional) 
            var searchField = "searchField_example";  // string? |  (optional) 
            var page = 1;  // int? |  (optional)  (default to 1)
            var perPage = 10;  // int? |  (optional)  (default to 10)
            var sortBy = "sortBy_example";  // string? |  (optional) 
            var sortOrder = "\"asc\"";  // string? |  (optional)  (default to "asc")
            var filterBy = "\"\"";  // string? |  (optional)  (default to "")
            var filter = "\"\"";  // string? |  (optional)  (default to "")

            try
            {
                apiInstance.ApiAIFolderGetPaginatedGet(search, searchField, page, perPage, sortBy, sortOrder, filterBy, filter);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetPaginatedGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderGetPaginatedGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAIFolderGetPaginatedGetWithHttpInfo(search, searchField, page, perPage, sortBy, sortOrder, filterBy, filter);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetPaginatedGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string?** |  | [optional]  |
| **searchField** | **string?** |  | [optional]  |
| **page** | **int?** |  | [optional] [default to 1] |
| **perPage** | **int?** |  | [optional] [default to 10] |
| **sortBy** | **string?** |  | [optional]  |
| **sortOrder** | **string?** |  | [optional] [default to &quot;asc&quot;] |
| **filterBy** | **string?** |  | [optional] [default to &quot;&quot;] |
| **filter** | **string?** |  | [optional] [default to &quot;&quot;] |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldergetrangeget"></a>
# **ApiAIFolderGetRangeGet**
> List&lt;AIFolderDto&gt; ApiAIFolderGetRangeGet (List<Guid>? ids = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderGetRangeGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var ids = new List<Guid>?(); // List<Guid>? |  (optional) 

            try
            {
                List<AIFolderDto> result = apiInstance.ApiAIFolderGetRangeGet(ids);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetRangeGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderGetRangeGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<AIFolderDto>> response = apiInstance.ApiAIFolderGetRangeGetWithHttpInfo(ids);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderGetRangeGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **ids** | [**List&lt;Guid&gt;?**](Guid.md) |  | [optional]  |

### Return type

[**List&lt;AIFolderDto&gt;**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiaifoldersavepost"></a>
# **ApiAIFolderSavePost**
> AIFolderDto ApiAIFolderSavePost (AIFolderDto aIFolderDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAIFolderSavePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AIFolderApi(config);
            var aIFolderDto = new AIFolderDto(); // AIFolderDto | 

            try
            {
                AIFolderDto result = apiInstance.ApiAIFolderSavePost(aIFolderDto);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AIFolderApi.ApiAIFolderSavePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAIFolderSavePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AIFolderDto> response = apiInstance.ApiAIFolderSavePostWithHttpInfo(aIFolderDto);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AIFolderApi.ApiAIFolderSavePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aIFolderDto** | [**AIFolderDto**](AIFolderDto.md) |  |  |

### Return type

[**AIFolderDto**](AIFolderDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

