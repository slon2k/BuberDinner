using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

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

        public AuthResponse Login(LoginRequest request)
        {
            var user = userRepository.GetByEmail(request.email);

            if (user is null)
            {
                throw new Exception("Invalid credentials");
            }

            if (user.Password != request.password)
            {
                throw new Exception("Invalid credentials");
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

        public AuthResponse Register(RegisterRequest request)
        {
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