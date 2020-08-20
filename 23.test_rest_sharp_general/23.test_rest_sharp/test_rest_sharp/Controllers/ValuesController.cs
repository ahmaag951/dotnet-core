using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using test_rest_sharp.Communication;

namespace test_rest_sharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceCommunication _serviceCommunication;

        public ValuesController(IServiceCommunication serviceCommunication)
        {
            _serviceCommunication = serviceCommunication;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // we need to call https://localhost:44313/api/values
            var test = _serviceCommunication.GetList<string>("values").Result;

            return Ok(test);
        }

    }
}
