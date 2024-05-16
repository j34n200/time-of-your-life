using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace time_of_your_life.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        [HttpGet, Route("syncTime")]
        public DateTime SyncServerTime()
        {
            return DateTime.Now;
        }
    }
}
