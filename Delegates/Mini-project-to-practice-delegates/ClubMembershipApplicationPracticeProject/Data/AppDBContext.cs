using ClubMembershipApplicationPracticeProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Data
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InmemroyDB");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id = -1,
                    EmailAddress = "induraperera3@gmail.com",
                    FirstName = "Indura",
                    LastName = "Perera",
                    Password = "VoidNon1@",
                    PhoneNumber = "+44 20 7123 4567",
                    Address = "102/London South, London",
                    PostCode = "GIR 0AA",
                    DateofBirth = DateTime.Parse("2000-06-18")
                }
            );

        }

        public DbSet<User> Users { get; set; }
    }
}
