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
    public class AdminsController : Controller
    {
        private readonly IAdminRepository _AdminRepository;
        private readonly DatabaseContext _context;
        //private object Admins;

        public AdminsController(DatabaseContext context, IAdminRepository adminRepository)
        {
            _context = context;
            _AdminRepository = adminRepository;
        }

        public IActionResult Index()
        {
            var model = _AdminRepository.GetAllAdmins();
            return View(model);
        }
    }
}
