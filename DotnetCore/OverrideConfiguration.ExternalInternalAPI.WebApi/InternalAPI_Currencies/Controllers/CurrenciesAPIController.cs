using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternalAPI_Currencies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesAPIController : ControllerBase
    {
        private readonly ILogger<CurrenciesAPIController> _logger;

        public CurrenciesAPIController(ILogger<CurrenciesAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello from CurrenciesAPI";
        }
    }
}
