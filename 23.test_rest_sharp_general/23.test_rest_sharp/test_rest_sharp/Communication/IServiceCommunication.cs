using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test_rest_sharp.Communication
{
    public interface IServiceCommunication
    {
        Task<T> Get<T>(string url);
        Task<IEnumerable<T>> GetList<T>(string url);
        Task Post<T>(string url, T obj);

    }
}
