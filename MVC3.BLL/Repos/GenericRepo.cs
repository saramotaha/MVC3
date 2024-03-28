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
    public class GenericRepo<T> : IGenericInterface<T> where T : ModelBase

    {

        private protected readonly AppDbContext _appDbContext;

        public GenericRepo(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;

        }


        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee)){
                return (IEnumerable<T>)_appDbContext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            }
            else
            {
                return _appDbContext.Set<T>().AsNoTracking().ToList();
            }
            
        }



        public T GetById(int id)
        {
            //var dept = _appDbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if(dept == null)
            //{
            //    dept = _appDbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
            //}

            //return dept;



            return _appDbContext.Set<T>().Find(id);
        }







        public int Add(T E)
        {
            _appDbContext.Set<T>().Add(E);

            return _appDbContext.SaveChanges();
        }




        public int Update(T E)
        {
            _appDbContext.Set<T>().Update(E);
            return (_appDbContext.SaveChanges());
        }




        public int Delete(T E)
        {
            _appDbContext.Set<T>().Remove(E);
            return (_appDbContext.SaveChanges());

        }
    }
}
