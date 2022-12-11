using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services
{
    internal class DateTimeProvider : IDateTimeProvider

    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
