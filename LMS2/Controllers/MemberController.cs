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
    public class MemberController : Controller
    {
        private readonly IMemberRepository _MemberRepository;
        private readonly IUserRepository _UserRegistrationRepository;
        private readonly DatabaseContext _context;
        //private object Users;

        public MemberController(DatabaseContext context, IUserRepository userRegistrationRepository, IMemberRepository memberRepository)
        {
            _context = context;
            _UserRegistrationRepository = userRegistrationRepository;
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
                MemberLogin MemberModel = _MemberRepository.MemberLoginAccess(member.UserName, member.Password);
                if (ModelState.IsValid)
                {
                    if (MemberModel != null &&  MemberModel.Access == true)
                    {
                        return View("Profile");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    //MemberModel.SuccessError = "incorrect password or username or status";
                    return View();
                }
                //UserRegistration AdminUser = _UserRegistrationRepository.GetUserRegistration(member.UserName);
                //if (AdminUser != null)
                //{
                //    _MemberRepository.Add(AdminUser);
                //    return View("Profile");
                //}
            }
            //ViewBag.Error = "Admin Not Found!";
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}
