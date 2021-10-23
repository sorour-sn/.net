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
        private readonly IUserRegistrationRepository _UserRegistrationRepository;
        private readonly DatabaseContext _context;
        //private object Users;

        public MemberController(DatabaseContext context, IUserRegistrationRepository userRegistrationRepository, IMemberRepository memberRepository)
        {
            _context = context;
            _UserRegistrationRepository = userRegistrationRepository;
            _MemberRepository = memberRepository;
        }

        public IActionResult Index()
        {
            var model = _MemberRepository.GetAllMembers();
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(MemberLogin member)
        {
            if (ModelState.IsValid)
            {
                MemberLogin MemberModel = _MemberRepository.GetMember(member.UserName); ////add checking password!
                if (MemberModel != null)
                {
                    return View("Profile");
                }
                UserRegistration AdminUser = _UserRegistrationRepository.GetUserRegistration(member.UserName);
                if (AdminUser != null)
                {
                    _MemberRepository.Add(member);
                    return View("Profile");
                }
            }
            ViewBag.Error = "Admin Not Found!";
            return View();
        }
    }
}
