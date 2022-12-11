using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthResponse> Register(RegisterRequest request);

        ErrorOr<AuthResponse> Login(LoginRequest request);
    }
}