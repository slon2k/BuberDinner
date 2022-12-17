using BuberDinner.Application.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menu.Queries
{
    internal class GetMenusQueryHandler : IRequestHandler<GetMenusQuery, ErrorOr<IEnumerable<MenuEntity>>>
    {
        private readonly IMenuRepository menuRepository;

        public GetMenusQueryHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        async Task<ErrorOr<IEnumerable<MenuEntity>>> IRequestHandler<GetMenusQuery, ErrorOr<IEnumerable<MenuEntity>>>.Handle(GetMenusQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            try
            {
                var result =  menuRepository.GetForHost(request.HostId);

                return result.ToList();
            }
            catch (Exception e)
            {
                return Error.Failure("Menu.GetMenus", e.Message);
            }

        }
    }
}
