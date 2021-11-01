using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS2.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace LMS2.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _MemberRepository;
        private readonly IUserRepository _UserRepository;
        private readonly ILogger _logger;
        private readonly DatabaseContext _context;
        //private object Users;

        public MemberController(DatabaseContext context, IUserRepository userRepository, IMemberRepository memberRepository, ILogger<MemberController> logger)
        {
            _context = context;
            _UserRepository = userRepository;
            _MemberRepository = memberRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var model = _MemberRepository.GetAllMembers();
            //return View(model);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(MemberLogin member, string ReturnUrl)
        {
            //GetMember(member.UserName);
            if (ModelState.IsValid)
            {
                MemberLogin memberModel = _MemberRepository.GetMember(member.UserName); 
                if ( memberModel != null) //if the username is valid in database and is member go to profile view
                {
                    MemberLogin MemberModel = _MemberRepository.MemberLoginAccess(member.UserName, member.Password);
                    if (MemberModel != null)
                    {
                        var Claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, MemberModel.UserName)                           
                        };
                        var claimsIdentity = new ClaimsIdentity(Claims, "Login");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        var Status = "Member";
                        HttpContext.Session.SetString("_Username", MemberModel.UserName);
                        HttpContext.Session.SetString("_Status", Status);
                        ViewData["Username"] = HttpContext.Session.GetString("_Username");
                        return Redirect(ReturnUrl == null ? "/Member/Profile" : ReturnUrl );
                        //return View("Profile");
                    }
                }
                else //if the username is valid in users database and is member first transfer data to members then go to profile view
                {
                    UserRegistration UserModel = _UserRepository.GetUser(member.UserName);
                    if (UserModel != null)
                    {
                        MemberLogin newMember = _MemberRepository.Add(UserModel);
                        MemberLogin NewMember = _MemberRepository.MemberLoginAccess(newMember.UserName, newMember.Password);
                        if (NewMember != null)
                        {
                            var Claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.Name, NewMember.UserName)
                            };
                            var claimsIdentity = new ClaimsIdentity(Claims, "Login");
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                            var Status = "Member";
                            HttpContext.Session.SetString("_Username", NewMember.UserName);
                            HttpContext.Session.SetString("_Status", Status);
                            return Redirect(ReturnUrl == null ? "/Member/Profile" : ReturnUrl);
                        }
                    }
                }
                return View(); 
            }
            //ViewBag.Error = "Admin Not Found!";
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
        public IActionResult Detail()
        {
            var user = _UserRepository.GetUser(HttpContext.Session.GetString("_Username"));
            return View(user);
        }

        //public IActionResult Edit()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(UserRegistration updateMember)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        updateMember.isAdmin = false;
        //        updateMember.UserName = HttpContext.Session.GetString("_Username");
        //        UserRegistration userUpdate = _UserRepository.Update(updateMember);
        //        //_MemberRepository.Update(updateMember);
        //    }
        //    return View("Profile");
        //}
    }
}
