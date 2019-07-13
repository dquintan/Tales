using Newtonsoft.Json;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pasajes.Repository
{
    public class GenericRepository : IGenericRepository
    {
        public async Task<T> GetAsync<T>(string uri, string authToken)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);
 
                var responseMessage = await Policy.Handle<WebException>(ex =>
                {
                    //add logging here
                    return true;
                })
                // Wait a retry, up to 5 times.
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

                if (responseMessage.IsSuccessStatusCode)
                {
                    var message = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var result = JsonConvert.DeserializeObject<T>(message);
                    return result;
                }

                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // throw new ServiceAuthenticationException
                }

                throw new Exception();
                //throw new HttpRequestException(responseMessage.StatusCode, content);
            } catch (Exception)
            {
                throw new Exception();
            }
        }

        private HttpClient CreateHttpClient(string authToken)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            return httpClient;
        }
    }
}
