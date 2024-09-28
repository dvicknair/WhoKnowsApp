using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace WhoKnowsApp.APIClient.Endpoints
{
    public class BaseEndpoint
    {
        public readonly HttpClient _apiHttpClient;
        public BaseEndpoint(IHttpClientFactory httpClientFactory, string serviceName)
        {
            _apiHttpClient = httpClientFactory.CreateClient("WhoKnowsApp.ServerAPI");
            _apiHttpClient.BaseAddress = new Uri(_apiHttpClient.BaseAddress + $"{serviceName}/");
        }

        public static string GetMethodName([CallerMemberName] string callerName = "") => callerName;

        public static async Task<T> HandleJsonResponse<T>(HttpResponseMessage response, JsonSerializerOptions options = null)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<T>(options);
                case HttpStatusCode.NotFound:
                    throw new KeyNotFoundException();
                default:
                    throw new ApplicationException(response.ReasonPhrase);
            }
        }

        public static async Task<string> ProcessStringResponse(HttpResponseMessage result) => result.StatusCode == HttpStatusCode.OK ? await result.Content.ReadAsStringAsync() : throw new Exception();

        public static void EvaluateResponseCode(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.NotFound:
                    throw new KeyNotFoundException();
                default:
                    throw new ApplicationException(response.ReasonPhrase);
            }
        }
    }
}