using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public IQueryable<User> GetAllUsers(bool trackChanges)
        {
            return GetAll(trackChanges)
                .OrderBy(b => b.UserName);

        }

        public User GetUserbyId(string userId, bool trackChanges)
        {
            return GetByCondition(x => x.Id == userId, trackChanges)
                .SingleOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
