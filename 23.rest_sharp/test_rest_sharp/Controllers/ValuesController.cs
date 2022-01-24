using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace test_rest_sharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // we need to call https://localhost:44313/api/values
            var client = new RestClient("https://localhost:44313/api/");

            var request = new RestRequest("values");
            //request.AddParameter("string name", "object value");

            List<string> test = new List<string>();

            var response1 = client.Get(request);
            var response2 = client.ExecuteAsync<List<string>>(request,
                (response) => test = response.Data);

            TestAwait(client, request);


            return test;
        }

        private void TestAwait(RestClient client, RestRequest request)
        {
            client.ExecuteAsync(request, CallBack);
        }

        private void CallBack(IRestResponse arg1, RestRequestAsyncHandle arg2)
        {
            var debug = arg1.Content;
        }
    }
}
