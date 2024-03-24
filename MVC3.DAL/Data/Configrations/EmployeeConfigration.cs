using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.DAL.Data.Configrations
{
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Salary).HasColumnType("decimal(12,2)");
            builder.Property(p => p.Gender).HasConversion(

                (Gender) => Gender.ToString(),
                (gender) =>(Gender) Enum.Parse(typeof(Gender), gender ,true));

        }
    }
}
