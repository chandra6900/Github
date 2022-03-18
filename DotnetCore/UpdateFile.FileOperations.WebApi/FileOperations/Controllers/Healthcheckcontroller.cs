using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileOperations.Controllers
{
    [Route("")]
    [Route("[Controller]")]
    [ApiController]
    public class Healthcheckcontroller : ControllerBase
    {
        const string HealthCheckSuccess = "Health Check Successful";

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public ActionResult<string> Get()
        {
            return HealthCheckSuccess;
        }
    }
}
