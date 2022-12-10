namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthResponse Login(LoginRequest request)
        {
            return new AuthResponse(
                id: new Guid(),
                firstName: request.email,
                lastName: request.email,
                email: request.email,
                token: "token"
            );
        }

        public AuthResponse Register(RegisterRequest request)
        {
            return new AuthResponse(
                id: new Guid(),
                firstName: request.firstName,
                lastName: request.lastName,
                email: request.email,
                token: "token"
            );
        }
    }
}