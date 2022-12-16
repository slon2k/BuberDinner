using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public static MenuItem Create(string name, string description) => new(MenuItemId.CreateUnique(), name, description);
    }
}
