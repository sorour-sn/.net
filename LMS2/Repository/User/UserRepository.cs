using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class UserRepository : IUserRepository
    {
        private List<UserRegistration> _userRegistrationList;

        public UserRegistration Add(UserRegistration addUser)
        {
            addUser.UserName = _userRegistrationList.Max(u => u.UserName);
            _userRegistrationList.Add(addUser);
            return addUser;
        }

        public UserRegistration Delete(string userName)
        {
            UserRegistration deleteUser = _userRegistrationList.FirstOrDefault(u => u.UserName == userName);
            if(deleteUser != null)
            {
                _userRegistrationList.Remove(deleteUser);
            }
            return deleteUser;
        }

        public IEnumerable<UserRegistration> GetAllUsers()
        {
            return _userRegistrationList;
        }

        public UserRegistration GetUser(string UserName)
        {
            return _userRegistrationList.FirstOrDefault(u => u.UserName == UserName);
        }

        public UserRegistration Update(UserRegistration updateUser)
        {
            UserRegistration userChanges = _userRegistrationList.FirstOrDefault(u => u.UserName == updateUser.UserName);
            if (userChanges != null)
            {
                userChanges.FirstName = updateUser.FirstName;
                userChanges.LastName = updateUser.LastName;
                userChanges.Address = updateUser.Address;
                userChanges.City = updateUser.City;
                userChanges.Country = updateUser.Country;
                userChanges.DoB = updateUser.DoB;
                userChanges.UserName = updateUser.UserName;
                userChanges.Password = updateUser.Password;
            }
            return userChanges;
        }

    }
}
