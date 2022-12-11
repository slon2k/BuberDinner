using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetById(Guid id);

        User? GetByEmail(string email);
    }
}
