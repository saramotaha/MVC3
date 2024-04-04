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


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee)){
                return (IEnumerable<T>) await _appDbContext.Employees.Include(E => E.Department).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
            }
            
        }



        public async Task<T> GetByIdAsync(int id)
        {
            //var dept = _appDbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if(dept == null)
            //{
            //    dept = _appDbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
            //}

            //return dept;



            return await _appDbContext.Set<T>().FindAsync(id);
        }







        public void Add(T E)
        {
            _appDbContext.Set<T>().Add(E);

            //return _appDbContext.SaveChanges();
        }




        public void Update(T E)
        {
            _appDbContext.Set<T>().Update(E);
            //return (_appDbContext.SaveChanges());
        }




        public void Delete(T E)
        {
            _appDbContext.Set<T>().Remove(E);
            //return (_appDbContext.SaveChanges());

        }
    }
}
