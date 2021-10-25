using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class AdminRepository : IAdminRepository
    {
        private List<AdminLogin> _adminLoginList;
        public AdminLogin Add(AdminLogin addAdmin)
        {
            //addAdmin.UserName = _adminLoginList.Max(a => a.UserName);
            _adminLoginList.Add(addAdmin);
            return addAdmin;
        }

        public AdminLogin Delete(string userName)
        {
            AdminLogin deleteAdmin = _adminLoginList.FirstOrDefault(a => a.UserName == userName);
            if (deleteAdmin != null)
            {
                _adminLoginList.Remove(deleteAdmin);
            }
            return deleteAdmin;
        }

        public AdminLogin GetAdmin(string userName)
        {
            return _adminLoginList.FirstOrDefault(a => a.UserName == userName);
        }

        public IEnumerable<AdminLogin> GetAllAdmins()
        {
            return _adminLoginList;
        }

        public AdminLogin Update(AdminLogin updateAdmin)
        {
            AdminLogin adminChanges = _adminLoginList.FirstOrDefault(a => a.UserName == updateAdmin.UserName);
            if (adminChanges != null)
            {
                adminChanges.FirstName = updateAdmin.FirstName;
                adminChanges.UserName = updateAdmin.UserName;
                adminChanges.Password = updateAdmin.Password;

            }
            return adminChanges;
        }
        AdminLogin AdminLoginAccess(string userName, string password)
        {
            AdminLogin admin = _adminLoginList.FirstOrDefault(a => a.UserName == userName && a.Password == password && a.isAdmin == false);
            if (admin != null)
            {
                admin.Access = true;
            }
            admin.Access = false;
            return admin;
        }

        AdminLogin IAdminRepository.AdminLoginAccess(string userName, string password)
        {
            throw new NotImplementedException();
        }

        //AdminLogin IAdminRepository.AdminLoginAccess(string userName, string password)
        //{
        //    AdminLogin member = _adminLoginList.FirstOrDefault(a => a.UserName == userName && a.Password == password && a.isAdmin == false);
        //    if (member != null)
        //    {
        //        member.Access = true;
        //    }
        //    member.Access = false;
        //    return member;
        //}
    }
}
