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

namespace LMS2.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _MemberRepository;
        private readonly IUserRepository _UserRepository;
        private readonly DatabaseContext _context;
        //private object Users;

        public MemberController(DatabaseContext context, IUserRepository userRepository, IMemberRepository memberRepository)
        {
            _context = context;
            _UserRepository = userRepository;
            _MemberRepository = memberRepository;
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
        public IActionResult Login(MemberLogin member)
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
                        var Status = "Member";
                        HttpContext.Session.SetString("_Username", MemberModel.UserName);
                        HttpContext.Session.SetString("_Status", Status);
                        ViewData["Username"] = HttpContext.Session.GetString("_Username");
                        return View("Profile");
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
                            var Status = "Member";
                            HttpContext.Session.SetString("_Username", NewMember.UserName);
                            HttpContext.Session.SetString("_Status", Status);
                            return View("Profile");
                        }
                    }
                }
                return View(); 
            }
            //ViewBag.Error = "Admin Not Found!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_Username");
            HttpContext.Session.Remove("_Status");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            return View();
        }

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
