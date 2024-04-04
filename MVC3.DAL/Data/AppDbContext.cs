using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class AppDbContext: IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) :base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }




    }
}
