using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public interface IAdminRepository
    {
        AdminLogin GetAdmin(string userName);
        IEnumerable<AdminLogin> GetAllAdmins();
        AdminLogin Add(AdminLogin addAdmin);
        AdminLogin Update(AdminLogin updateAdmin);
        AdminLogin Delete(string userName);
    }
}
