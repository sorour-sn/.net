using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LMS2.Models
{
    public class AdminLogin
    {
        //public const string SessionKeyName = "_Name";
        //public const string SessionKeyRole = "_Role";
        //const string SessionKeyTime = "_Time";

        public string FirstName { get; set; }
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public string SuccessError { get; set; }
        public bool Access { get; set; }

        //public static void OnGet()
        //{
        //    var admin = new AdminLogin();
            
        //    // Requires: using Microsoft.AspNetCore.Http;
        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
        //    {
        //        HttpContext.Session.SetString(SessionKeyName, "The Doctor");
        //        HttpContext.Session.SetInt32(SessionKeyRole, 773);
        //    }

        //    var name = HttpContext.Session.GetString(SessionKeyName);
        //    var role = HttpContext.Session.GetString(SessionKeyRole);
        //}
    }
}
