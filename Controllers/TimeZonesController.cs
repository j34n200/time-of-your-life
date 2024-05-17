using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace time_of_your_life.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeZonesController : ControllerBase
    {
        private static HttpClient _httpClient = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var timeZoneStr = await _httpClient.GetStringAsync("https://worldtimeapi.org/api/timezone");
            List<string> timeZoneList = new List<string>();
            if (timeZoneStr.Length > 0)
            {
                timeZoneList = JsonSerializer.Deserialize<List<string>>(timeZoneStr);

            }
            return Ok(timeZoneList);
        }
    }
}
