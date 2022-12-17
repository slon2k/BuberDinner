using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    public class DinnerController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult GetDinners() 
        {
            return Ok(new List<string>());
        }
    }
}
