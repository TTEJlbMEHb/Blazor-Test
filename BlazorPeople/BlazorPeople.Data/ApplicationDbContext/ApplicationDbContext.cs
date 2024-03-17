using BlazorPeople.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeople.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Firstname = "Vlad", Lastname = "Linnik", Age = 20, Occupation = Domain.Enum.Occupation.Searching },
                new Person { Id = 2, Firstname = "Dima", Lastname = "Granovkiy", Age = 20, Occupation = Domain.Enum.Occupation.Employed },
                new Person { Id = 3, Firstname = "Yan", Lastname = "Klevanets", Age = 19, Occupation = Domain.Enum.Occupation.Unemployed }
            );
        }
    }
}
