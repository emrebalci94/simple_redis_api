using Microsoft.AspNetCore.Mvc;

namespace simple_redis_api.Controllers
{
    public class BaseController : ControllerBase
    {

        public IActionResult ServiceResponse(object data)
        {
            return StatusCode(200, new { data });
        }
    }
}