using BuberDinner.Application.Common.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtGenerator jwtGenerator;

        public AuthenticationService(IJwtGenerator jwtGenerator)
        {
            this.jwtGenerator = jwtGenerator;
        }

        public AuthResponse Login(LoginRequest request)
        {
            var id = Guid.NewGuid();

            var token = jwtGenerator.GenerateToken(id, request.email, request.email);
            
            return new AuthResponse(
                id: Guid.NewGuid(),
                firstName: request.email,
                lastName: request.email,
                email: request.email,
                token: token
            );
        }

        public AuthResponse Register(RegisterRequest request)
        {
            var id = Guid.NewGuid();
            
            var token = jwtGenerator.GenerateToken(id, request.firstName, request.lastName);

            return new AuthResponse(
                id: id,
                firstName: request.firstName,
                lastName: request.lastName,
                email: request.email,
                token: token
            );
        }
    }
}