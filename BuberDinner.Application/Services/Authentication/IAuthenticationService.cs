namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthResponse Register(RegisterRequest request);

        AuthResponse Login(LoginRequest request);        
    }
}