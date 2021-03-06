using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookCreate
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        [Display(Name = "ISBN")]
        public string BookID { get; set; }

        //[Required]
        //public string Title { get; set; }

        
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

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
