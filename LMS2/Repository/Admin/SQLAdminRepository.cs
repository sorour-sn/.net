using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLAdminRepository :IAdminRepository
    {
        private readonly DatabaseContext context;

        public SQLAdminRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public AdminLogin Add(AdminLogin addAdmin)
        {
            context.Admins.Add(addAdmin);
            context.SaveChanges();
            return addAdmin;
        }

        public AdminLogin Delete(string userName)
        {
            AdminLogin admin = context.Admins.Find(userName);
            if (admin != null)
            {
                context.Admins.Remove(admin);
                context.SaveChanges();
            }
            return admin;
        }

        public AdminLogin GetAdmin(string userName)
        {
            return context.Admins.Find(userName);
        }

        public IEnumerable<AdminLogin> GetAllAdmins()
        {
            return context.Admins;
        }

        public AdminLogin Update(AdminLogin updateAdmin)
        {
            var aAdmin = context.Admins.Attach(updateAdmin);
            aAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateAdmin;
        }

        public AdminLogin AdminLoginAccess(string userName, string password)
        {
            AdminLogin model = context.Admins.AsQueryable().Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            if (model == null)
            {
                model.SuccessError = "Your username or password or status is incorrect!";
            }
            return model;
        }
    }
}
