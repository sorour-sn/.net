using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class MemberRepository : IMemberRepository
    {
        private List<MemberLogin> _memberLoginList;

        public MemberLogin Add(MemberLogin addMember)
        {
            addMember.UserName = _memberLoginList.Max(a => a.UserName);
            _memberLoginList.Add(addMember);
            return addMember;
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
    }
}
