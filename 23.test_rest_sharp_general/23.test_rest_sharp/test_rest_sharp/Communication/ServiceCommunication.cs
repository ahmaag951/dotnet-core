using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test_rest_sharp.RestSharp;

namespace test_rest_sharp.Communication
{
    public class ServiceCommunication : IServiceCommunication
    {
        private readonly IRestSharpContainer _restSharpContainer;
        public ServiceCommunication(IRestSharpContainer restSharpContainer)
        {
            _restSharpContainer = restSharpContainer;
        }
        public async Task<IEnumerable<T>> GetList<T>(string url)
        {
            var result = await _restSharpContainer.SendRequest<IEnumerable<T>>($"{url}", global::RestSharp.Method.GET);
            return result;
        }
        public async Task<T> Get<T>(string url)
        {
            var result = await _restSharpContainer.SendRequest<T>($"{url}", global::RestSharp.Method.GET);
            return result;
        }
    }
}
