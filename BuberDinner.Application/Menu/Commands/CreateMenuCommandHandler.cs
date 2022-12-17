using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menu.Commands
{
    internal class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenuResult>>
    {
        public async Task<ErrorOr<MenuResult>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Error.NotFound("Menu.NotImplemented", "Menu creation is not implemented yet");
        }
    }
}
