using BuberDinner.Application.Menu.Commands;
using BuberDinner.Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/host/{hostId}/menus")]
    public class MenusController : ApiControllerBase
    {
        private readonly ISender mediator;
        private readonly IMapper mapper;

        public MenusController(ISender mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMenus(string hostId)
        {
            return Ok(hostId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuAsync(CreateMenuRequest request, string hostId)
        {
            var result = await mediator.Send(mapper.Map<CreateMenuCommand>((request, hostId)));

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
