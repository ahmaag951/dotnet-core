using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private MyDatabaseContext _myDatabaseContext;
        public ValuesController(MyDatabaseContext myDatabaseContext)
        {
            _myDatabaseContext = myDatabaseContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return _myDatabaseContext.Departments.ToList(); 
        }

    }
}
