using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public interface IUserRegistrationRepository
    {
        UserRegistration GetUserRegistration(string UserName);
        IEnumerable<UserRegistration> GetAllUsers();
        UserRegistration Add(UserRegistration addUser);
        UserRegistration Update(UserRegistration updateUser);   //use for user management
        UserRegistration Delete(string userName);
    }
}
