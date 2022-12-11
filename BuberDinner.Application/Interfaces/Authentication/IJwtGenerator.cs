using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
