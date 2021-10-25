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
        public IActionResult Index()
        {
            var model = _BookRepository.GetAllBooks(); //correct!
            return View(model);
        }

        public IActionResult Add(BookCreate book)
        {
            if (ModelState.IsValid)
            {
                _BookRepository.Add(book);
                return View("Index");
            }

            return View();
        }
    }
}
