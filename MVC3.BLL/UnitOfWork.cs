using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly AppDbContext _appDbContext;

        public IEmployeeInterface EmployeeRepositry { get; set; } = null;
        public IDeptInterface DepartmentRepositry { get; set; } = null;

        public UnitOfWork(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
            EmployeeRepositry =new EmployeeRepo(_appDbContext);
            DepartmentRepositry =new DeptRepo(_appDbContext);
           
        }

        public int complete()
        {
           return _appDbContext.SaveChanges();

        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
