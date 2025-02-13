# Org.OpenAPITools.Api.AITopicApi

All URIs are relative to *https://localhost:7209*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiAITopicAddPost**](AITopicApi.md#apiaitopicaddpost) | **POST** /api/AITopic/Add |  |
| [**ApiAITopicAddRangePost**](AITopicApi.md#apiaitopicaddrangepost) | **POST** /api/AITopic/AddRange |  |
| [**ApiAITopicCountGet**](AITopicApi.md#apiaitopiccountget) | **GET** /api/AITopic/Count |  |
| [**ApiAITopicDeleteAllByRangeDelete**](AITopicApi.md#apiaitopicdeleteallbyrangedelete) | **DELETE** /api/AITopic/DeleteAllByRange |  |
| [**ApiAITopicDeleteAllDelete**](AITopicApi.md#apiaitopicdeletealldelete) | **DELETE** /api/AITopic/DeleteAll |  |
| [**ApiAITopicDeleteDelete**](AITopicApi.md#apiaitopicdeletedelete) | **DELETE** /api/AITopic/Delete |  |
| [**ApiAITopicGetAllGet**](AITopicApi.md#apiaitopicgetallget) | **GET** /api/AITopic/GetAll |  |
| [**ApiAITopicGetGet**](AITopicApi.md#apiaitopicgetget) | **GET** /api/AITopic/Get |  |
| [**ApiAITopicGetLastOrDefaultGet**](AITopicApi.md#apiaitopicgetlastordefaultget) | **GET** /api/AITopic/GetLastOrDefault |  |
| [**ApiAITopicGetPaginatedGet**](AITopicApi.md#apiaitopicgetpaginatedget) | **GET** /api/AITopic/GetPaginated |  |
| [**ApiAITopicGetRangeGet**](AITopicApi.md#apiaitopicgetrangeget) | **GET** /api/AITopic/GetRange |  |
| [**ApiAITopicSavePost**](AITopicApi.md#apiaitopicsavepost) | **POST** /api/AITopic/Save |  |

<a id="apiaitopicaddpost"></a>
# **ApiAITopicAddPost**
> AITopicDto ApiAITopicAddPost (AITopicDto aITopicDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicAddPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var aITopicDto = new AITopicDto(); // AITopicDto | 

            try
            {
                AITopicDto result = apiInstance.ApiAITopicAddPost(aITopicDto);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicAddPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicAddPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AITopicDto> response = apiInstance.ApiAITopicAddPostWithHttpInfo(aITopicDto);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicAddPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aITopicDto** | [**AITopicDto**](AITopicDto.md) |  |  |

### Return type

[**AITopicDto**](AITopicDto.md)

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

<a id="apiaitopicaddrangepost"></a>
# **ApiAITopicAddRangePost**
> void ApiAITopicAddRangePost (List<AITopicDto> aITopicDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicAddRangePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var aITopicDto = new List<AITopicDto>(); // List<AITopicDto> | 

            try
            {
                apiInstance.ApiAITopicAddRangePost(aITopicDto);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicAddRangePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicAddRangePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAITopicAddRangePostWithHttpInfo(aITopicDto);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicAddRangePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aITopicDto** | [**List&lt;AITopicDto&gt;**](AITopicDto.md) |  |  |

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

<a id="apiaitopiccountget"></a>
# **ApiAITopicCountGet**
> int ApiAITopicCountGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicCountGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);

            try
            {
                int result = apiInstance.ApiAITopicCountGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicCountGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicCountGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAITopicCountGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicCountGetWithHttpInfo: " + e.Message);
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

<a id="apiaitopicdeleteallbyrangedelete"></a>
# **ApiAITopicDeleteAllByRangeDelete**
> int ApiAITopicDeleteAllByRangeDelete (List<Guid> requestBody)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicDeleteAllByRangeDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var requestBody = new List<Guid>(); // List<Guid> | 

            try
            {
                int result = apiInstance.ApiAITopicDeleteAllByRangeDelete(requestBody);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteAllByRangeDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicDeleteAllByRangeDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAITopicDeleteAllByRangeDeleteWithHttpInfo(requestBody);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteAllByRangeDeleteWithHttpInfo: " + e.Message);
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

<a id="apiaitopicdeletealldelete"></a>
# **ApiAITopicDeleteAllDelete**
> int ApiAITopicDeleteAllDelete (bool? areYouSure = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicDeleteAllDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var areYouSure = true;  // bool? |  (optional) 

            try
            {
                int result = apiInstance.ApiAITopicDeleteAllDelete(areYouSure);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteAllDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicDeleteAllDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<int> response = apiInstance.ApiAITopicDeleteAllDeleteWithHttpInfo(areYouSure);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteAllDeleteWithHttpInfo: " + e.Message);
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

<a id="apiaitopicdeletedelete"></a>
# **ApiAITopicDeleteDelete**
> void ApiAITopicDeleteDelete (Guid? id = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicDeleteDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var id = "id_example";  // Guid? |  (optional) 

            try
            {
                apiInstance.ApiAITopicDeleteDelete(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicDeleteDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAITopicDeleteDeleteWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicDeleteDeleteWithHttpInfo: " + e.Message);
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

<a id="apiaitopicgetallget"></a>
# **ApiAITopicGetAllGet**
> List&lt;AITopicDto&gt; ApiAITopicGetAllGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicGetAllGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);

            try
            {
                List<AITopicDto> result = apiInstance.ApiAITopicGetAllGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicGetAllGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicGetAllGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<AITopicDto>> response = apiInstance.ApiAITopicGetAllGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicGetAllGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;AITopicDto&gt;**](AITopicDto.md)

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

<a id="apiaitopicgetget"></a>
# **ApiAITopicGetGet**
> AITopicDto ApiAITopicGetGet (Guid? id = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicGetGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var id = "id_example";  // Guid? |  (optional) 

            try
            {
                AITopicDto result = apiInstance.ApiAITopicGetGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicGetGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicGetGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AITopicDto> response = apiInstance.ApiAITopicGetGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicGetGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid?** |  | [optional]  |

### Return type

[**AITopicDto**](AITopicDto.md)

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

<a id="apiaitopicgetlastordefaultget"></a>
# **ApiAITopicGetLastOrDefaultGet**
> AITopicDto ApiAITopicGetLastOrDefaultGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicGetLastOrDefaultGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);

            try
            {
                AITopicDto result = apiInstance.ApiAITopicGetLastOrDefaultGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicGetLastOrDefaultGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicGetLastOrDefaultGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AITopicDto> response = apiInstance.ApiAITopicGetLastOrDefaultGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicGetLastOrDefaultGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**AITopicDto**](AITopicDto.md)

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

<a id="apiaitopicgetpaginatedget"></a>
# **ApiAITopicGetPaginatedGet**
> void ApiAITopicGetPaginatedGet (string? search = null, string? searchField = null, int? page = null, int? perPage = null, string? sortBy = null, string? sortOrder = null, string? filterBy = null, string? filter = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicGetPaginatedGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
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
                apiInstance.ApiAITopicGetPaginatedGet(search, searchField, page, perPage, sortBy, sortOrder, filterBy, filter);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicGetPaginatedGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicGetPaginatedGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiAITopicGetPaginatedGetWithHttpInfo(search, searchField, page, perPage, sortBy, sortOrder, filterBy, filter);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicGetPaginatedGetWithHttpInfo: " + e.Message);
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

<a id="apiaitopicgetrangeget"></a>
# **ApiAITopicGetRangeGet**
> List&lt;AITopicDto&gt; ApiAITopicGetRangeGet (List<Guid>? ids = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicGetRangeGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var ids = new List<Guid>?(); // List<Guid>? |  (optional) 

            try
            {
                List<AITopicDto> result = apiInstance.ApiAITopicGetRangeGet(ids);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicGetRangeGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicGetRangeGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<AITopicDto>> response = apiInstance.ApiAITopicGetRangeGetWithHttpInfo(ids);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicGetRangeGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **ids** | [**List&lt;Guid&gt;?**](Guid.md) |  | [optional]  |

### Return type

[**List&lt;AITopicDto&gt;**](AITopicDto.md)

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

<a id="apiaitopicsavepost"></a>
# **ApiAITopicSavePost**
> AITopicDto ApiAITopicSavePost (AITopicDto aITopicDto)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiAITopicSavePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new AITopicApi(config);
            var aITopicDto = new AITopicDto(); // AITopicDto | 

            try
            {
                AITopicDto result = apiInstance.ApiAITopicSavePost(aITopicDto);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AITopicApi.ApiAITopicSavePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiAITopicSavePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<AITopicDto> response = apiInstance.ApiAITopicSavePostWithHttpInfo(aITopicDto);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AITopicApi.ApiAITopicSavePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aITopicDto** | [**AITopicDto**](AITopicDto.md) |  |  |

### Return type

[**AITopicDto**](AITopicDto.md)

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

