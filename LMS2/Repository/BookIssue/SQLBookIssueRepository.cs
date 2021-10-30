using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLBookIssueRepository : IBookIssueRepository
    {
        private List<BookIssue> _bookIssuelist;
        private readonly DatabaseContext context;
        public SQLBookIssueRepository(DatabaseContext context) 
        {
            this.context = context;
        }

        public BookIssue Issue(string userName, string bookId)
        {
            //BookIssue.HasNoKey();
            MemberLogin member = context.Members.Find(userName);
            BookCreate book = context.Books.Find(bookId);
            BookIssue issueBook = new BookIssue();
            issueBook.IssueId = context.BookIssues.Max(a => a.IssueId) + 1;
            //issueBook.IssueId = _bookIssuelist.Max(a => a.IssueId)+1;
            issueBook.BookID = book.BookID;
            issueBook.BookName = book.BookName;
            issueBook.UserName = member.UserName;
            issueBook.FirstName = member.FirstName;
            issueBook.Issue_Date = DateTime.Today.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.Now;
            issueBook.Due_Date = dt.AddMonths(1).ToString();

            context.BookIssues.Add(issueBook);
            context.SaveChanges();
            return issueBook;
        }

        public IEnumerable<BookIssue> GetAllIssuedBooks(string memberUsername)
        {
            return context.BookIssues.Where(x => x.UserName == memberUsername);    //NO idea is it correct or not yet!   
        }
    }
}
