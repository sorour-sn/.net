using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS2.Models
{
    public class MemberLogin 
    {
        //public const string SessionKeyName = "_Username";

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Key]
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Enter your Username")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Enter the Password")]
        public string Password { get; set; }

        [Display(Name ="Status")]
        public bool isAdmin { get; set; }
        public string? SuccessError { get; set; }
        public bool? Access { get; set; }

        public void OnGet()
        {
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
        //    {
        //        HttpContext.Session.SetString(SessionKeyName, "Member");
        //    }
        //    var name = HttpContext.Session.GetString(SessionKeyName);
        }
    }
}
