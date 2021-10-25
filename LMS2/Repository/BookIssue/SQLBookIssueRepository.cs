using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLBookIssueRepository : SQLBookRepository, IBookIssueRepository
    {
        private readonly DatabaseContext context;
        public SQLBookIssueRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public BookIssue Issue(string userName, string bookName)
        {
            throw new NotImplementedException();
        }
    }
}
