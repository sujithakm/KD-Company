using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class UserAppDbContext:DbContext
    {
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<CarDetails> cardetails { get; set; }
        public DbSet<Adminlogin> adminlogins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=CarRental;Trusted_Connection=True;");
        }
    }
}
