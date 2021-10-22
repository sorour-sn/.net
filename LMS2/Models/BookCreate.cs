using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookCreate
    {
        [Key]
        [Display(Name = "Book Id")]
        public int BookID { get; set; }

        public string Image { get; set; }

        [Display(Name = "Book Name")]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
    }
}
