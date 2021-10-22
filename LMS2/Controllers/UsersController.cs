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
    public class UsersController : Controller
    {
        private readonly DatabaseContext _context;
        private object Users;

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserName == id); //hereeeeeeeeeeeeeeeee was FirstName
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,ContactNumber,DoB,Country,City,Address,UserName,Password,ConfirmPassword,isAdmin")] UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                if (user.isAdmin == true) //admin
                {
                    var admin = from u in UserRegistration
                            where u.UserName == user.UserName
                            select new AdminLogin
                            {
                                FirstName = user.FirstName,
                                UserName = user.UserName,
                                Password = user.Password,
                                isAdmin = user.isAdmin
                            };

                   //admin.FirstName = user.FirstName;
                    //admin.isAdmin = user.isAdmin;
                    //admin.Password = user.Password;
                    //admin.UserName = user.UserName;
                    //admin = user;
                    _context.Add(admin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var member = from u in UserRegistration
                            where u.UserName == user.UserName
                            select new MemberLogin
                            {
                                FirstName = user.FirstName,
                                UserName = user.UserName,
                                Password = user.Password,
                                isAdmin = user.isAdmin
                            };
                    //MemberLogin member = new MemberLogin();
                    //member.FirstName = user.FirstName;
                    //member.isAdmin = user.isAdmin;
                    //member.Password = user.Password;
                    //member.UserName = user.UserName;
                    _context.Add(member);
                    await _context.SaveChangesAsync();
                }
                //_context.Add(user);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Email,ContactNumber,DoB,Country,City,Address,UserName,Password,ConfirmPassword,isAdmin")] UserRegistration user)
        {
            if (id != user.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.UserName == id);
        }

        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(string id, [Bind("UserName,Password,isAdmin")] MemberLogin member)
        {
            if (id != member.UserName || member.isAdmin == true)
            {
                ViewBag.ErrorLogin = "user not found!";
                //return NotFound();
                return View();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("UserProfile");
                //try
                //{
                //    _context.Update(user);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!UserExists(user.UserName))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //return RedirectToAction(nameof(Index));
            }
        //    return View(user);
        //    if (ModelState.IsValid)
        //    {
        //        var e = from u in UserRegistration
        //                join m in member on u.UserName equals m.UserName
        //                where u.Password == m.Password && u.isAdmin == m.isAdmin == false
        //                select new
        //                {
        //                    V = member.FirstName = u.FirstName
        //                };

        //        _context.Add(member);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(member);
        //}
        //public ActionResult UserLogin(MemberLogin  MemberModel)
        //{
        //    //private DatabaseContext dbc = new DatabaseContext(); 
        //    //UserRegistration UserModel = new UserRegistration();

        //    var model = from user in DatabaseContext.Users
        //                join member in  DatabaseContext.Members on user.UserName equals member.UserName /*&& user.Password equals member.Password,*/
        //                where user.isAdmin == member.isAdmin == true && user.Password == member.Password && user.UserName == member.UserName
        //                select new 
        //                {
        //                    FirstName = user.FirstName
        //                };
                 
        //                         //join dealer in Dealer on contact.DealerId equals dealer.ID
        //                         //select contact;

        //    //var model = from u in Users
        //    //                   where MemberModel.UserName == u.UserName && MemberModel.Password == u.Password && MemberModel.isAdmin == u.isAdmin == true
        //    //                   select new
        //    //                   {
        //    //                       model.isAdmin = true,
        //    //                       model.FirstName = MemberModel.FirstName,
        //    //                       model.UserName = MemberModel.UserName,
        //    //                       model.Password = MemberModel.Password,
        //    //                   };


        //    //FROM u in Users 
        //    //    join m in Members 
        //    //    where m.

        //    //var model = await (from p in _context.Members()
        //    //                   join e in _context.Users on p.PatientID equals e.PatientID
        //    //                   select new { No = e.AppointmentNo, Date = e.AppointmentDate, Name = p.FullName, Ref = e.RefDoctor }.ToListAsync();



        //    return View(model);
        //}
        //public ActionResult Login(MemberLogin MemberModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (UserRegistration UserModel = new UserRegistration())
        //        {
        //            var v = UserModel.CustomerCallerLists.Where(a => a.Name.Equals(c.Name) && a.Password.Equals(c.Password)).FirstOrDefault();
        //            if (v != null)
        //            {
        //                Session["LoginID"] = v.ID.ToString();
        //                Session["LoginUser"] = v.Name.ToString();
        //                return RedirectToAction("AfterLogin");
        //            }
        //        }
        //    }
        //    return View(c);
        }
    }
}
