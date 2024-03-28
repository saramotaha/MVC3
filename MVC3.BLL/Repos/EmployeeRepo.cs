using Microsoft.EntityFrameworkCore;
using MVC3.BLL.Interfaces;
using MVC3.DAL.Data;
using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Repos
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeInterface
    {
        public EmployeeRepo(AppDbContext appDbContext) :base(appDbContext)
        {
            
        }
        public IQueryable<Employee> GetEmpByAddress(string address)
        {
            return _appDbContext.Employees.Where(w => w.Address.ToLower() == address.ToLower());
        }

        public IQueryable<Employee> SeachByName(string name)
        {
            return _appDbContext.Employees.Where(w => w.Name.ToLower().Contains(name));
        }
    }
}
