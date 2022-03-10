using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
