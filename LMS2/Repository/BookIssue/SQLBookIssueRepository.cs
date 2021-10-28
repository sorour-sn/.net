using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLBookIssueRepository : IBookIssueRepository
    {
        private readonly DatabaseContext context;
        public SQLBookIssueRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public BookIssue Issue(string userName, int bookId)
        {
            
            MemberLogin member = context.Members.Find(userName);
            BookCreate book = context.Books.Find(bookId);
            BookIssue issuBook = new BookIssue();
            issuBook.BookID = book.BookID;
            issuBook.BookName = book.BookName;
            issuBook.UserName = member.UserName;
            issuBook.FirstName = member.FirstName;

            context.BookIssues.Add(issuBook);
            context.SaveChanges();
            return issuBook;
        }
    }
}
