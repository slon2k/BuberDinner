using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetById(Guid id);

        User? GetByEmail(string email);
    }
}
