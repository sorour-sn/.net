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
        public MemberLogin Add(UserRegistration addMember)
        {
            MemberLogin member = new MemberLogin();
            member.FirstName = addMember.FirstName;
            member.UserName = addMember.UserName;
            member.Password = addMember.Password;
            member.isAdmin = addMember.isAdmin;
            context.Members.Add(member);
            context.SaveChanges();
            return member;           
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

        public MemberLogin MemberLoginAccess(string userName, string password)
        {
            MemberLogin model = context.Members.Find(userName);
            if (model != null)
            {
                if (model.Password == password)
                {
                    model.SuccessError = "Successed!";
                }
            }

            //MemberLogin model = context.Members.AsQueryable().Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            //if (model != null)
            //{
            //    model.SuccessError = "Successed!";
            //}           
            return model;
        }
    }
}
