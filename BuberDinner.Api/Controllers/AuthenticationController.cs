using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Contracts.RegisterRequest request)
        {
            var result = await mediator.Send(MapRegisterCommand(request));

            return result.Match(
                result => Ok(MapAuthResponse(result)),
                errors => Problem(errors));
        }        
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(Contracts.LoginRequest request)
        {
            var result = await mediator.Send(new LoginQuery(
                Email: request.email,
                Password: request.password
            ));

            return result.Match(
                result => Ok(MapAuthResponse(result)),
                errors => Problem(errors));

        }

        private static Contracts.AuthResponse MapAuthResponse(AuthResponse response) => new(
            id: response.Id,
            firstName: response.FirstName,
            lastName: response.LastName,
            email: response.Email,
            token: response.Token
        );

        private static RegisterCommand MapRegisterCommand(Contracts.RegisterRequest request) => new(
            FirstName: request.firstName,
            LastName: request.lastName,
            Email: request.email,
            Password: request.password
        );
    }
}