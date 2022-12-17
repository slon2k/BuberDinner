using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        private readonly List<MenuItem> items = new(); 

        public IReadOnlyList<MenuItem> Items => items.AsReadOnly();
        
        private MenuSection(MenuSectionId id, string name, string description, IEnumerable<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            this.items.AddRange(items);
        }

        public static MenuSection Create(string name, string description, IEnumerable<MenuItem> items) => 
            new(MenuSectionId.CreateUnique(), name, description, items);

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
