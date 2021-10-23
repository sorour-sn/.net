using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS2.Models;


namespace LMS2.Controllers
{
    public class BookManagement : Controller
    {
        //private readonly IRepository<BookCreate> repository;
        //public CreateModel(IRepository<BookCreate> repository)
        //{
        //    this.repository = repository;

        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult CreateBook()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateBook([Bind("BookID,Image,BookName,Author,Publisher,Description")] BookCreate book)
        //{
        //    if (ModelState.IsValid)
        //        await repository.CreateAsync(book);
        //    return View();
        //}
    }
}
