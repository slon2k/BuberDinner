using BuberDinner.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(request);
        }        
        
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}