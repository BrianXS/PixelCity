using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Notifications")]
    public class NotificationController : ControllerBase
    {
        [HttpGet("Test")]
        public JsonResult Notification()
        {
            return new JsonResult(new {Value = 5}) ;
        }
    }
}