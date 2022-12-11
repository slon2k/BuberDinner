using BuberDinner.Application.Interfaces;

namespace BuberDinner.Infrastructure.Services
{
    internal class DateTimeProvider : IDateTimeProvider

    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
