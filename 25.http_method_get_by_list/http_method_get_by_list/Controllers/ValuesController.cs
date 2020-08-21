using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace http_method_get_by_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        // [FromUri] exists only on mvc and in api it's FromQuery
        public ActionResult<IEnumerable<string>> Get([FromQuery] int[] ids)
        {
            // you can call it like this ==> https://localhost:44314/api/values?ids=1&ids=2
            return new string[] { "value1", "value2" };
        }

    }

}
