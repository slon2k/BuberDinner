using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        private readonly IList<MenuItem> items = new List<MenuItem>(); 

        public IReadOnlyList<MenuItem> Items => items.AsReadOnly();
        
        private MenuSection(MenuSectionId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description) => new(MenuSectionId.CreateUnique(), name, description);

        public void Add(MenuItem item)
        {
            items.Add(item);
        }

        public void Remove(MenuItem item)
        {
            items.Remove(item);
        }
    }
}
