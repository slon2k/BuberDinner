using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResponse>>
    {
        private readonly IJwtGenerator jwtGenerator;

        private readonly IUserRepository userRepository;

        public LoginQueryHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            this.jwtGenerator = jwtGenerator;
            this.userRepository = userRepository;
        }


        public async Task<ErrorOr<AuthResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (userRepository.GetByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != request.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = jwtGenerator.GenerateToken(user);

            return new AuthResponse(
                Id: user.Id,
                FirstName: user.FirstName,
                LastName: user.LastName,
                Email: user.Email,
                Token: token
            );
        }
    }
}
