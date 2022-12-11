using BuberDinner.Application.Services.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(Contracts.RegisterRequest request)
        {
            var result = authenticationService.Register(MapRegisterRequest(request));

            return result.Match(
                res => Ok(MapAuthResponse(res)),
                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error[0].Description));
        }        
        
        [HttpPost("login")]
        public IActionResult Login(Contracts.LoginRequest request)
        {
            var result = authenticationService.Login(new LoginRequest(
                email: request.email,
                password: request.password
            ));

            return result.Match(
                result => Ok(MapAuthResponse(result)),
                error => Problem(statusCode: StatusCodes.Status400BadRequest, title: error[0].Description));

        }

        private static Contracts.AuthResponse MapAuthResponse(AuthResponse response) => new(
            id: response.id,
            firstName: response.firstName,
            lastName: response.lastName,
            email: response.email,
            token: response.token
        );

        private static RegisterRequest MapRegisterRequest(Contracts.RegisterRequest request) => new(
            firstName: request.firstName,
            lastName: request.lastName,
            email: request.email,
            password: request.password
        );
    }
}