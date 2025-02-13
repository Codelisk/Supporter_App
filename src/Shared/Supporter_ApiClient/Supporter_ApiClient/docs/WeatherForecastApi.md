# Org.OpenAPITools.Api.WeatherForecastApi

All URIs are relative to *https://localhost:7209*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetWeatherForecast**](WeatherForecastApi.md#getweatherforecast) | **GET** /WeatherForecast |  |

<a id="getweatherforecast"></a>
# **GetWeatherForecast**
> List&lt;WeatherForecast&gt; GetWeatherForecast ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetWeatherForecastExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://localhost:7209";
            var apiInstance = new WeatherForecastApi(config);

            try
            {
                List<WeatherForecast> result = apiInstance.GetWeatherForecast();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WeatherForecastApi.GetWeatherForecast: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWeatherForecastWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<WeatherForecast>> response = apiInstance.GetWeatherForecastWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WeatherForecastApi.GetWeatherForecastWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;WeatherForecast&gt;**](WeatherForecast.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

