using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lookups.WebAPI.Controllers.Base
{
    /// <inheritdoc />
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
       
        /// <inheritdoc />
        public BaseController()
        {
        }
    }
}
