using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQlUserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly DatabaseContext context;

        public SQlUserRegistrationRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public UserRegistration Add(UserRegistration addUser)
        {
            context.Users.Add(addUser);
            context.SaveChanges();
            return addUser;
        }

        public UserRegistration Delete(string userName)
        {

            UserRegistration user = context.Users.Find(userName);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<UserRegistration> GetAllUsers()
        {
            return context.Users;
        }

        public UserRegistration GetUserRegistration(string UserName)
        {
            return context.Users.Find(UserName);
        }

        public UserRegistration Update(UserRegistration updateUser)
        {
            var uUser =  context.Users.Attach(updateUser);
            uUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateUser;
        }
    }
}
