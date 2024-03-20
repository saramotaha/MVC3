using Microsoft.EntityFrameworkCore;
using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.DAL.Data
{
    internal class AppDbContext:DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AppMVC3;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        public DbSet<Department> Departments { get; set; }




    }
}
