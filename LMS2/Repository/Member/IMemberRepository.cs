using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public interface IMemberRepository 
    {
        MemberLogin GetMember(string userName);
        IEnumerable<MemberLogin> GetAllMembers();
        MemberLogin Add(UserRegistration addMember);
        MemberLogin Update(MemberLogin updateMember);
        MemberLogin Delete(string userName);
        MemberLogin MemberLoginAccess(string userName, string password);
    }
}
