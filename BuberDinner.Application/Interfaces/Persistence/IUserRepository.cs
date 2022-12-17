using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetById(Guid id);

        User? GetByEmail(string email);
    }
}
