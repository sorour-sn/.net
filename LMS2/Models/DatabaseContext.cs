using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<UserRegistration> Users { get; set; }
        public DbSet<MemberLogin> Members { get; set; }
        public DbSet<AdminLogin> Admins { get; set; }
        public DbSet<BookCreate> Books { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
    }
}
