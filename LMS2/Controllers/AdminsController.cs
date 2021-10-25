﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS2.Models;
using Microsoft.AspNetCore.Http;

namespace LMS2.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IUserRepository _userRegistrationRepository;
        private readonly IAdminRepository _AdminRepository;
        private readonly DatabaseContext _context;

        public AdminsController(DatabaseContext context, IAdminRepository adminRepository, IUserRepository userRegistrationRepository)
        {
            _context = context;
            _AdminRepository = adminRepository;
            _userRegistrationRepository = userRegistrationRepository;
        }

        public IActionResult Index()
        {
            var model = _AdminRepository.GetAllAdmins();
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
                AdminLogin AdminModel = _AdminRepository.GetAdmin(admin.UserName); ////add checking password!
                if( AdminModel != null)
                {
                    //ISession.Set(AdminModel.FirstName, Byte[32]);
                    return View("Profile");                    
                }
                UserRegistration AdminUser = _userRegistrationRepository.GetUserRegistration(admin.UserName);
                if (AdminUser != null)
                {
                    _AdminRepository.Add(admin);
                    return View("Profile");
                }
            }
            ViewBag.Error = "Admin Not Found!";
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public IActionResult ViewMembers()
        {
            var model = _userRegistrationRepository.GetAllUsers();
            return View(model);
        }
    }
}