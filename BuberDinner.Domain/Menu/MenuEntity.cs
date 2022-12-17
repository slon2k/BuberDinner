using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuEntity : AggregateRoot<MenuId>
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal AverageRating { get; set; }

        public Guid HostId { get; set; }

        public DateTimeOffset CreatedDateTime { get; }

        public DateTimeOffset UpdatedDateTime { get; private set; }

        private readonly IList<MenuSection> sections = new List<MenuSection>();

        private MenuEntity(MenuId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
            CreatedDateTime= DateTimeOffset.Now;
            UpdatedDateTime= DateTimeOffset.Now;
        }

        public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

        public static MenuEntity Create(string name, string description) => new(MenuId.CreateUnique(), name, description);
    }
}
