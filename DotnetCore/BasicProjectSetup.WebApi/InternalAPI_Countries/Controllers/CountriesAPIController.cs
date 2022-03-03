using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalAPI_Countries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesAPIController : ControllerBase
    {

        private readonly ILogger<CountriesAPIController> _logger;

        public CountriesAPIController(ILogger<CountriesAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string  Get()
        {
            return "Hello from CountriesAPI";
        }
    }
}
