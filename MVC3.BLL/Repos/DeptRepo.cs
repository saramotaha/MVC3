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
    internal class DeptRepo : IDeptInterface
    {
        private readonly AppDbContext _appDbContext;

        public DeptRepo(AppDbContext  appDbContext)
        {

            _appDbContext = appDbContext;
            
        }
        public int Add(Department d)
        {
            _appDbContext.Departments.Add(d);

            return (_appDbContext.SaveChanges());
        }

        public int Delete(Department d)
        {
            _appDbContext.Departments.Remove(d);
            return (_appDbContext.SaveChanges());

        }

        public IEnumerable<Department> GetAll()
        {
            return _appDbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            //var dept = _appDbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if(dept == null)
            //{
            //    dept = _appDbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
            //}

            //return dept;



            return _appDbContext.Departments.Find(id);
        }

        public int Update(Department d)
        {
            _appDbContext.Departments.Update(d);
            return (_appDbContext.SaveChanges());
        }
    }
}
