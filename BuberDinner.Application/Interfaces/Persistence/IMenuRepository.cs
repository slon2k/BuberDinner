using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(MenuEntity menu);

        IEnumerable<MenuEntity> GetForHost(string hostId);

        MenuEntity? GetById(Guid id);
    }
}
