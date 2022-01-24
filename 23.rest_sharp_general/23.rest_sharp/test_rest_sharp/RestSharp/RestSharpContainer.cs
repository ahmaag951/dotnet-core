using System;
using System.Collections.Generic;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Serialization.Json;
using Microsoft.AspNetCore.Http;

namespace test_rest_sharp.RestSharp
{
    public class RestSharpContainer : IRestSharpContainer
    {
        private readonly RestClient _client;
        private readonly string _serverUri;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RestSharpContainer(string serverUri)
        {
            _httpContextAccessor = new HttpContextAccessor();
            _serverUri = serverUri;
            _client = new RestClient { Timeout = Timeout.Infinite, ReadWriteTimeout = Timeout.Infinite };
        }
        public async Task<T> GetRequest<T>(string uri, Method method)
        {
            _client.CookieContainer = new CookieContainer();
            var request = new RestRequest($"{_serverUri}{uri}", method);

            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            var response = await _client.ExecuteAsync<T>(request);
            T data;
            try { data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content); }
            catch (Exception) { data = default(T); }
            return data == null ? response.Data : data;
        }

        public async Task SendRequest<T>(string uri, Method method, T obj)
        {
            _client.CookieContainer = new CookieContainer();
            var request = new RestRequest($"{_serverUri}{uri}", method);
            if (method == Method.POST || method == Method.PUT)
            {
                SetJsonContent(request, obj);
                request.AddJsonBody(obj);
            }
            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            await _client.ExecuteAsync<T>(request);            
        }

        private void SetJsonContent(RestRequest request, object obj)
        {
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddJsonBody(obj);
        }

    }
}
