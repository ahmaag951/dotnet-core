using System;
using System.Collections.Generic;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
            var options = new RestClientOptions(serverUri)
            {
                MaxTimeout = Timeout.Infinite
            };
            _client = new RestClient(options);
        }

        public async Task<T> GetRequest<T>(string uri, Method method)
        {
            var request = new RestRequest($"{_serverUri}{uri}", method);
            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            var response = await _client.ExecuteAsync<T>(request);
            T data;
            try { data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content); }
            catch (Exception) { data = default(T); }
            return data == null ? response.Data : data;
        }

        public async Task SendRequest<T>(string uri, Method method, T obj) where T : class
        {
            var request = new RestRequest($"{_serverUri}{uri}", method);
            if (method == Method.Post || method == Method.Put)
            {
                request.AddJsonBody(obj);
            }
            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            await _client.ExecuteAsync<T>(request);
        }
    }
}
