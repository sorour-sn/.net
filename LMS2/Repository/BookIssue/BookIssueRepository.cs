using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookIssueRepository : BookRepository, IBookIssueRepository
    {
        private List<BookCreate> _bookList;
        private List<MemberLogin> _memberLoginList;
        private List<BookIssue> _bookIssuelist;

        public BookIssue Issue(string userName, string bookName)
        {
            BookIssue bookIssue = new BookIssue();
            MemberLogin member = _memberLoginList.FirstOrDefault(x => x.UserName == userName);
            if (member != null)
            {
                BookCreate book = _bookList.FirstOrDefault(x => x.BookName == bookName);
                if (book != null)
                {
                    bookIssue.BookID = book.BookID;
                    bookIssue.BookName = book.BookName;
                    bookIssue.UserName = member.UserName;
                    bookIssue.FirstName = member.FirstName;
                }
            }
            return bookIssue;
        }
    }
}
