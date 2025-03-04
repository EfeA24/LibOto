using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetUserByName(string FullName, bool trackChanges);
        User CreateUser (User user);
        void UpdateUser (string FullName, User user, bool trackChanges);
        void DeleteUser (string FullName, bool trackChanges);
    }
}
