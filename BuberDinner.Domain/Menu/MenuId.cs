using BuberDinner.Domain.Common;

namespace BuberDinner.Domain.Menu
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique() => new(Guid.NewGuid());

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value; 
        }
    }
}