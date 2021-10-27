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
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _BookRepository;
        private readonly DatabaseContext _context;
        public BookManagementController(DatabaseContext context, IBookRepository bookRepository)
        {
            _context = context;
            _BookRepository = bookRepository;
        }
        public IActionResult ViewBooks()
        {
            var model = _BookRepository.GetAllBooks(); 
            return View(model);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(BookCreate addBook)
        {
            //if (ModelState.IsValid)
            //{
                _BookRepository.Add(addBook);
                //return View("ViewBooks");
                //return RedirectToAction("Profile", "Admins");
                //return View("ViewBooks");
            //}
            return View();
        }
    }
}
