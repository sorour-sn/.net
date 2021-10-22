using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class AdminLogin
    {
        public string FirstName { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
