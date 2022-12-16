using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique() => new(Guid.NewGuid());

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value; 
        }
    }
}