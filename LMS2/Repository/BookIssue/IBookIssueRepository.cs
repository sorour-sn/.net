using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    interface IBookIssueRepository : IBookRepository
    {
        BookIssue Issue(string userName, string bookName);

    }
}
