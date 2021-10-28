using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookCreate
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Display(Name = "Book Id")]
        public int BookID { get; set; }

        [Required]
        public string Image { get; set; }

        [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Stock { get; set; }
    }
}
