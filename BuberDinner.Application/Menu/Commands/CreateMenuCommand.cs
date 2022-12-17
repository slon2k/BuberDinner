using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menu.Commands
{
    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<CreateMenuSection> Sections
        ) : IRequest<ErrorOr<MenuResult>>;

    public record CreateMenuSection(
        string Name,
        string Description,
        List<CreateMenuItem> Items
        );

    public record CreateMenuItem(
        string Name,
        string Description
        );
}
