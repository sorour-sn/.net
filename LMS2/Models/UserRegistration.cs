using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class UserRegistration
    {
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Enter your First Name",AllowEmptyStrings =false)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter your Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name ="Date of Birthday")]
        public string DoB { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Key]
        [Required(ErrorMessage ="Enter your User Name", AllowEmptyStrings = false)]
        [Display(Name ="User Name")]
        //[Index(isUnique=true)]      ////unique validation!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter Password", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Admin")]
        public bool isAdmin { get; set; }
    }
}
