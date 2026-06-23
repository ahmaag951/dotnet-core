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
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            // we need to call https://localhost:44313/api/values
            var client = new RestClient("https://localhost:44313/api/");

            var request = new RestRequest("values");

            // synchronous GET
            var response1 = await client.GetAsync(request);

            // async execute returning typed response
            var response2 = await client.ExecuteAsync<List<string>>(request);
            var test = response2.Data ?? new List<string>();

            await TestAwait(client, request);

            return test;
        }

        private async Task TestAwait(RestClient client, RestRequest request)
        {
            var response = await client.ExecuteAsync(request);
            CallBack(response);
        }

        private void CallBack(RestResponse response)
        {
            var debug = response.Content;
        }
    }
}

