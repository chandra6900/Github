using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalAPIController : ControllerBase
    {

        private readonly ILogger<ExternalAPIController> _logger;

        public ExternalAPIController(ILogger<ExternalAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello from ExternalAPI";
        }
    }
}
