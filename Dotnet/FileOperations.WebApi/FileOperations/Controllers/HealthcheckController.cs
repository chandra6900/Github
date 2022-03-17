using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileOperations.Controllers
{
    [Route("[Controller]")]
    public class HealthcheckController : ApiController
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            var message = "HealthCheckSuccess";
            //return Request.CreateResponse(HttpStatusCode.OK, "HealthCheckSuccess");
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain")
            };
            return httpResponseMessage;
        }
    }
}
