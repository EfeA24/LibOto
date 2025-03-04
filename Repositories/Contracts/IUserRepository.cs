using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> GetAllUsers(bool trackChanges);
        User GetUserById(string userId, bool trackChanges);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
