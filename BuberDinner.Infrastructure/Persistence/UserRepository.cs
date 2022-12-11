using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence
{  
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new();        
        
        public void Add(User user)
        {
            var entity = GetByEmail(user.Email);
            
            if (entity is not null)
            {
                throw new Exception("user already exists");
            }

            users.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return users.Find(x => x.Email == email);
        }

        public User? GetById(Guid id)
        {
            return users.Find(x => x.Id == id);
        }
    }
}
