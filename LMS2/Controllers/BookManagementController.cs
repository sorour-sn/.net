using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS2.Models;
using LMS2.Repository.Book;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace LMS2.Controllers
{
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _BookRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DatabaseContext _context;
        public BookManagementController(DatabaseContext context, IBookRepository bookRepository, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _BookRepository = bookRepository;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> AddAsync(BookCreate addBook)
        {
            if (ModelState.IsValid)
            {
                BookCreate newBook = new BookCreate();
                newBook.BookID = addBook.BookID;
                newBook.BookName = addBook.BookName;
                newBook.Author = addBook.Author;
                newBook.Publisher = addBook.Publisher;
                newBook.Description = addBook.Description;
                newBook.Image = addBook.Image;    
                string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string fileName = Path.GetFileNameWithoutExtension(addBook.ImageFile.FileName);
                string extension = Path.GetExtension(addBook.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                newBook.Image = fileName;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await addBook.ImageFile.CopyToAsync(fileStream);
                }

                _BookRepository.Add(newBook);              
                return View("ViewBooks");
            }
            return View();
        }

        public IActionResult BookDetail(string Id)
        {
            BookCreate bookDetail = _BookRepository.GetBook(Id);
            return View(bookDetail);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult BookDetail(string Id)
        //{
        //    BookCreate bookDetail =  _BookRepository.GetBook(Id); 
        //    return View(bookDetail);
        //}
    }
}
