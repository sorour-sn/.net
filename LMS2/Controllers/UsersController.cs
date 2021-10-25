using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS2.Models;

namespace LMS2.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _UserRegistrationRepository;
        private readonly DatabaseContext _context;
        //private object Users;

        public UsersController(DatabaseContext context,IUserRepository userRegistrationRepository)
        {
            _context = context;
            _UserRegistrationRepository = userRegistrationRepository;
        }

        // GET: Users
        public IActionResult Index()
        {
            var model = _UserRegistrationRepository.GetAllUsers();
            return View(model);
        }
        
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                _UserRegistrationRepository.Add(userRegistration);
                if(userRegistration.isAdmin == true)
                {
                    //Session["admin-username"] = userRegistration.UserName;
                    return RedirectToAction("Profile", "Admins");
                }
                else
                {
                    return RedirectToAction("Profile", "Members");
                }
            }
            ViewBag.SuccessMessage = "Something went wrong! Please try again.";
            return View();
        }
    }
}
