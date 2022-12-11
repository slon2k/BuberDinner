using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await mediator.Send(mapper.Map<RegisterCommand>(request));

            return result.Match(
                result => Ok(mapper.Map<AuthResponse>(result)),
                errors => Problem(errors));
        }        
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await mediator.Send(mapper.Map<LoginQuery>(request));

            return result.Match(
                result => Ok(mapper.Map<AuthResponse>(result)),
                errors => Problem(errors));
        }
    }
}