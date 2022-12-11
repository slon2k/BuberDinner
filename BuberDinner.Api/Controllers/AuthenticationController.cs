using BuberDinner.Application.Services.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiControllerBase
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
                result => Ok(MapAuthResponse(result)),
                errors => Problem(errors));
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
                errors => Problem(errors));

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