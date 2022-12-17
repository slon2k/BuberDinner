using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/host/{hostId}/menus")]
    public class MenusController : ApiControllerBase
    {
        private readonly ISender mediator;

        public MenusController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetMenus(string hostId)
        {
            return Ok(hostId);
        }
    }
}
