using MVC3.BLL.Interfaces;
using MVC3.BLL.Repos;
using MVC3.DAL.Data;
using MVC3.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly AppDbContext _appDbContext;
        private Hashtable _Repositries;

        //public IEmployeeInterface EmployeeRepositry { get; set; } = null;
        //public IDeptInterface DepartmentRepositry { get; set; } = null;

        public UnitOfWork(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
            _Repositries = new Hashtable();
            //EmployeeRepositry =new EmployeeRepo(_appDbContext);
            //DepartmentRepositry =new DeptRepo(_appDbContext);
           
        }

        public int complete()
        {
           return _appDbContext.SaveChanges();

        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public IGenericInterface<T> Repo<T>() where T : ModelBase
        {
            var key = typeof(T).Name;

            if (!_Repositries.ContainsKey(key))
            {

                if(key==nameof(Employee))
                {
                    var repositry = new EmployeeRepo(_appDbContext);
                    _Repositries.Add(key, repositry);

                }
                else
                {

                    var repositry = new GenericRepo<T>(_appDbContext);
                    _Repositries.Add(key, repositry);

                }
               
                
            }
            return _Repositries[key] as IGenericInterface<T>;
        }
    }
}
