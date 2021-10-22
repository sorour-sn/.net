using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class MemberLogin
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Key]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
