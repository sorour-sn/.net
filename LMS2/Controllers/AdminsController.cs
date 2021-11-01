using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LMS2.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IUserRepository _userRegistrationRepository;
        private readonly IAdminRepository _AdminRepository;
        private readonly ILogger _logger;

        private readonly DatabaseContext _context;

        public AdminsController(DatabaseContext context, IAdminRepository adminRepository, IUserRepository userRegistrationRepository, ILogger<AdminsController> logger)
        {
            _context = context;
            _AdminRepository = adminRepository;
            _userRegistrationRepository = userRegistrationRepository;
            _logger = logger;
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
        public async Task<IActionResult> LoginAsync(AdminLogin admin, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                AdminLogin AdminModel = _AdminRepository.GetAdmin(admin.UserName); ////add checking password!
                if( AdminModel != null)
                {
                    var Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, AdminModel.UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(Claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    var Status = "Admin";
                    HttpContext.Session.SetString("_Status", Status);
                    HttpContext.Session.SetString("_Username", AdminModel.UserName);
                    return Redirect(ReturnUrl == null ? "/Admins/Profile" : ReturnUrl);
                    //return View("Profile");                    
                }
                UserRegistration AdminUser = _userRegistrationRepository.GetUser(admin.UserName);
                if (AdminUser != null)
                {
                    var Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, AdminUser.UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(Claims, "Login");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    _AdminRepository.Add(admin);
                    var Status = "Admin";
                    HttpContext.Session.SetString("_Status", Status);
                    HttpContext.Session.SetString("_Username", AdminUser.UserName);
                    return Redirect(ReturnUrl == null ? "/Admins/Profile" : ReturnUrl);
                }
            }
            ViewBag.Error = "Admin Not Found!";
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            HttpContext.Session.Remove("_Username");
            HttpContext.Session.Remove("_Status");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public IActionResult ViewMembers()
        {
            var model = _userRegistrationRepository.GetAllUsers();
            return View(model);
        }

        [Authorize]
        public IActionResult UsersList()
        {
            var allUsers = _userRegistrationRepository.GetAllUsers();
            return View(allUsers);
        }
    }
}
