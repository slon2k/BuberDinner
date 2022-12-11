using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResponse>>
    {
        private readonly IJwtGenerator jwtGenerator;

        private readonly IUserRepository userRepository;

        public RegisterCommandHandler(IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            this.jwtGenerator = jwtGenerator;
            this.userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (userRepository.GetByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            userRepository.Add(user);

            var token = jwtGenerator.GenerateToken(user);

            return new AuthResponse(
                Id: user.Id,
                FirstName: command.FirstName,
                LastName: command.LastName,
                Email: command.Email,
                Token: token
            );
        }
    }
}
