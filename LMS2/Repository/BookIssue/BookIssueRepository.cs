using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private List<BookCreate> _bookList;
        private List<MemberLogin> _memberLoginList;
        private List<BookIssue> _bookIssuelist;

        public BookIssue Issue(string userName, string bookId)
        {
            BookIssue bookIssue = new BookIssue();
            MemberLogin member = _memberLoginList.FirstOrDefault(x => x.UserName == userName);
            if (member != null)
            {
                BookCreate book = _bookList.FirstOrDefault(x => x.BookID == bookId);
                //BookCreate book = _bookList.FirstOrDefault(a => a.BookID == bookId);
                if (book != null && book.Stock == false)
                {
                    book.Stock = true;
                    bookIssue.IssueId = _bookIssuelist.Max(a => a.IssueId) +1;
                    bookIssue.BookID = book.BookID;
                    bookIssue.BookName = book.BookName;
                    bookIssue.UserName = member.UserName;
                    bookIssue.FirstName = member.FirstName;
                    bookIssue.Due_Date = DateTime.Today.ToString("dd/MM/yyyy");
                }
            }
            return bookIssue;
        }

        public IEnumerable<BookIssue> GetAllIssuedBooks(string memberUsername)
        {
            return _bookIssuelist.Where(x => x.UserName == memberUsername);    //NO idea is it correct or not yet!   
        }
    }
}
