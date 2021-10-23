using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLMemberRepository : IMemberRepository
    {
        private readonly DatabaseContext context;
        public SQLMemberRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public MemberLogin Add(MemberLogin addMember)
        {
            context.Members.Add(addMember);
            context.SaveChanges();
            return addMember;
        }

        public MemberLogin Delete(string userName)
        {
            MemberLogin member = context.Members.Find(userName);
            if (member != null)
            {
                context.Members.Remove(member);
                context.SaveChanges();
            }
            return member;
        }

        public IEnumerable<MemberLogin> GetAllMembers()
        {
            return context.Members;
        }

        public MemberLogin GetMember(string userName)
        {
            return context.Members.Find(userName);
        }

        public MemberLogin Update(MemberLogin updateMember)
        {
            var mMember = context.Members.Attach(updateMember);
            mMember.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateMember;
        }
    }
}
