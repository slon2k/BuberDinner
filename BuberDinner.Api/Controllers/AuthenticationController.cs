using BuberDinner.Application.Services.Authentication;
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
            var result = authenticationService.Register(new RegisterRequest(
                firstName:  request.firstName,
                lastName: request.lastName,
                email: request.email,
                password: request.password
            ));

            return Ok(new Contracts.AuthResponse(
                id: result.id,
                firstName:  result.firstName,
                lastName: result.lastName,
                email: result.email,
                token: result.token                
            ));
        }        
        
        [HttpPost("login")]
        public IActionResult Login(Contracts.LoginRequest request)
        {
            var result = authenticationService.Login(new LoginRequest(
                email: request.email,
                password: request.password
            ));

            return Ok(new Contracts.AuthResponse(
                id: result.id,
                firstName:  result.firstName,
                lastName: result.lastName,
                email: result.email,
                token: result.token                
            ));
        }
    }
}