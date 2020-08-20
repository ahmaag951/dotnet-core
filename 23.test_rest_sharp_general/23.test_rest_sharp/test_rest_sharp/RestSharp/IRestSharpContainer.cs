using RestSharp;
using System.Threading.Tasks;

namespace test_rest_sharp.RestSharp
{
    public interface IRestSharpContainer
    {
        Task<T> SendRequest<T>(string uri, Method method, object obj = null);
    }
}
