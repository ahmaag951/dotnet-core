using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace test_foolproof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // install nuget package foolproof.Core

        [HttpPost]
        public ActionResult<string> Get(MyDto id)
        {
            return "value";
        }

    }
}
