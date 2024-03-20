using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.DAL.Data.Configrations
{
    internal class DeptConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.Property(I => I.Id).UseIdentityColumn(10, 10);
            builder.Property(n=>n.Name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.Property(n=>n.Code).IsRequired().HasMaxLength(50).HasColumnType("varchar");
           
        }
    }
}
