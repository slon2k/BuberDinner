using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
