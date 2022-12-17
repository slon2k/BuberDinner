using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menu.Queries
{
    public record GetMenusQuery(string HostId) : IRequest<ErrorOr<IEnumerable<MenuEntity>>>;
}
