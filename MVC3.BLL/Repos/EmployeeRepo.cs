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
    public class EmployeeRepo: IEmployeeInterface
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepo(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }


        public IEnumerable<Employee> GetAll()
        {
            return _appDbContext.Employees.AsNoTracking().ToList();
        }



        public Employee GetById(int id)
        {
            //var dept = _appDbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if(dept == null)
            //{
            //    dept = _appDbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
            //}

            //return dept;



            return _appDbContext.Employees.Find(id);
        }







        public int Add(Employee E)
        {
            _appDbContext.Employees.Add(E);

            return _appDbContext.SaveChanges();
        }


        

        public int Update(Employee E)
        {
            _appDbContext.Employees.Update(E);
            return (_appDbContext.SaveChanges());
        }




        public int Delete(Employee E)
        {
            _appDbContext.Employees.Remove(E);
            return (_appDbContext.SaveChanges());

        }

    }
}
