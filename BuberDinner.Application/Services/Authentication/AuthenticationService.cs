using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtGenerator jwtGenerator;

        private readonly IUserRepository userRepository;

        public AuthenticationService(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            this.jwtGenerator = jwtGenerator;
            this.userRepository = userRepository;
        }

        public ErrorOr<AuthResponse> Login(LoginRequest request)
        {
            if (userRepository.GetByEmail(request.email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != request.password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = jwtGenerator.GenerateToken(user);
            
            return new AuthResponse(
                id: user.Id,
                firstName: user.FirstName,
                lastName: user.LastName,
                email: user.Email,
                token: token
            );
        }

        public ErrorOr<AuthResponse> Register(RegisterRequest request)
        {
            if (userRepository.GetByEmail(request.email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User 
            {
                FirstName= request.firstName,
                LastName= request.lastName,
                Email = request.email,
                Password= request.password
            };

            userRepository.Add(user);
            
            var token = jwtGenerator.GenerateToken(user);

            return new AuthResponse(
                id: user.Id,
                firstName: request.firstName,
                lastName: request.lastName,
                email: request.email,
                token: token
            );
        }
    }
}