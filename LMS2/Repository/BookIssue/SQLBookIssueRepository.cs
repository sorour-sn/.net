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
            BookIssue issueBook = new BookIssue();
            issueBook.BookID = book.BookID;
            issueBook.BookName = book.BookName;
            issueBook.UserName = member.UserName;
            issueBook.FirstName = member.FirstName;
            issueBook.Due_Date = DateTime.Today.ToString("dd/MM/yyyy");

            context.BookIssues.Add(issueBook);
            context.SaveChanges();
            return issueBook;
        }
    }
}
