using BuberDinner.Application.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly HashSet<MenuEntity> menus = new();

        public void Add(MenuEntity menu)
        {
            menus.Add(menu);
        }

        public IEnumerable<MenuEntity> GetForHost(string hostId)
        {
            return menus.Where(m => m.HostId.Equals(hostId));
        }
    }
}
