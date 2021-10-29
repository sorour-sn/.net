﻿using System;
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
    public class IssuingController : Controller
    {
        private readonly IBookIssueRepository _BookIssueRepository;
        private readonly DatabaseContext _context;
        public IssuingController(DatabaseContext context, IBookIssueRepository bookIssueRepository)
        {
            _context = context;
            _BookIssueRepository = bookIssueRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Issue()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Issue(BookIssue IssuedBook)
        {
            if (ModelState.IsValid)
            {
                BookIssue newBookIssue =  _BookIssueRepository.Issue(IssuedBook.UserName, IssuedBook.BookID);
            }
            return View();
        }
    }
}
