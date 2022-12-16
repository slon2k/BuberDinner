﻿using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        private readonly IList<MenuSection> sections = new List<MenuSection>();

        private Menu(MenuId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();

        public static Menu Create(string name, string description) => new(MenuId.CreateUnique(), name, description);
    }
}
