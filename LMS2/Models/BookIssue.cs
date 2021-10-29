using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookIssue
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Issue_Date { get; set; }
        public string Due_Date { get; set; }
    }
}