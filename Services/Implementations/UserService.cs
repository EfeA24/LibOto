using Entities.Models;
using Services.Contracts;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CreateUser(User user)
        {
            _unitOfWork.User.CreateUser(user);
            _unitOfWork.Save(); // Commit changes
            return user;
        }

        public void DeleteUser(string fullName, bool trackChanges)
        {
            var user = _unitOfWork.User.GetUserById(fullName, trackChanges);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User  not found");
            }

            _unitOfWork.User.DeleteUser(user);
            _unitOfWork.Save(); // Commit changes
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _unitOfWork.User.GetAllUsers(trackChanges).ToList();
        }

        public User GetUserByName(string fullName, bool trackChanges)
        {
            var user = _unitOfWork.User.GetByCondition(u => u.FullName.Equals(fullName), trackChanges).SingleOrDefault();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User  not found");
            }
            return user;
        }

        public void UpdateUser(string fullName, User user, bool trackChanges)
        {
            var existingUser = _unitOfWork.User.GetUserById(fullName, trackChanges);
            if (existingUser == null)
            {
                throw new ArgumentNullException(nameof(existingUser), "User  not found");
            }

            existingUser.FullName = user.FullName;

            _unitOfWork.User.UpdateUser(existingUser);
            _unitOfWork.Save();
        }
    }
}