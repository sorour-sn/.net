using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class MemberRepository : IMemberRepository
    {
        private List<MemberLogin> _memberLoginList;
        public MemberLogin Add(UserRegistration addMember)
        {
            MemberLogin member = new MemberLogin();
            member.FirstName = addMember.FirstName;
            member.UserName = addMember.UserName;
            member.Password = addMember.Password;
            member.isAdmin = addMember.isAdmin;
            _memberLoginList.Add(member);
            return member;
        }

        public MemberLogin Delete(string userName)
        {
            MemberLogin deleteMember = _memberLoginList.FirstOrDefault(m => m.UserName == userName);
            if (deleteMember != null)
            {
                _memberLoginList.Remove(deleteMember);
            }
            return deleteMember;
        }

        public IEnumerable<MemberLogin> GetAllMembers()
        {
            return _memberLoginList;
        }

        public MemberLogin GetMember(string userName)
        {
            return _memberLoginList.FirstOrDefault(m => m.UserName == userName);
        }

        public MemberLogin Update(MemberLogin updateMember)
        {
            MemberLogin memberChanges = _memberLoginList.FirstOrDefault(a => a.UserName == updateMember.UserName);
            if (memberChanges != null)
            {
                memberChanges.FirstName = updateMember.FirstName;
                memberChanges.UserName = updateMember.UserName;
                memberChanges.Password = updateMember.Password;

            }
            return memberChanges;
        }

        public MemberLogin MemberLoginAccess(string userName, string password)
        {
            return _memberLoginList.FirstOrDefault(a => a.UserName == userName && a.Password == password && a.isAdmin == false);
        }
    }
}
