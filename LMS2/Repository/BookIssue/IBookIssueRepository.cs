using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public interface IBookIssueRepository 
    {
        BookIssue Issue(string userName, string bookId);
    }
}
