using Microsoft.EntityFrameworkCore;
using MVC3.BLL.Interfaces;
using MVC3.DAL.Data;
using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Repos
{
    public class DeptRepo : GenericRepo<Department>, IDeptInterface
    {
        public DeptRepo(AppDbContext appDbContext) :base(appDbContext)
        {
            
        }

    }
}
