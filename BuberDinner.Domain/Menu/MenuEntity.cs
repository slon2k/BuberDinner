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

        private readonly List<MenuSection> sections = new();

        private MenuEntity(MenuId id, string hostId, string name, string description, IEnumerable<MenuSection> sections) : base(id)
        {
            Name = name;
            Description = description;
            HostId = Guid.Parse(hostId);
            CreatedDateTime= DateTimeOffset.Now;
            UpdatedDateTime= DateTimeOffset.Now;
            this.sections.AddRange(sections);
        }

        public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

        public static MenuEntity Create(
            string hostId,
            string name,
            string description,
            IEnumerable<MenuSection> sections
            ) => new (
                MenuId.CreateUnique(),
                hostId,
                name,
                description,
                sections
            );
    }
}
