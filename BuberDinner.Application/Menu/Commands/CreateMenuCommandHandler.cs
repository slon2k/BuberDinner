using BuberDinner.Application.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menu.Commands
{
    internal class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenuEntity>>
    {
        private readonly IMenuRepository menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<ErrorOr<MenuEntity>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            try
            {
                var menu = MenuEntity.Create(
                    request.HostId,
                    request.Name,
                    request.Description,
                    request.Sections.Select(s => MenuSection.Create(
                        s.Name,
                        s.Description,
                        s.Items.Select(i => MenuItem.Create(i.Name, i.Description))
                        ))
                    );

                menuRepository.Add(menu);

                return menu;
            }
            catch (Exception e)
            {
                return Error.Failure("Menu.CreationFailure", e.Message);
            }
        }
    }
}
