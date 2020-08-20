using RestSharp;
using System.Threading.Tasks;

namespace test_rest_sharp.RestSharp
{
    public interface IRestSharpContainer
    {
        Task<T> GetRequest<T>(string uri, Method method);
        Task SendRequest<T>(string uri, Method method, T obj);
    }
}
