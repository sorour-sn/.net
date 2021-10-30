using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    //[Keyless]
    public class BookIssue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int IssueId { get; set; }
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Issue_Date { get; set; }
        public string Due_Date { get; set; }
    }
}