using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //public IEmployeeInterface EmployeeRepositry { get; set; }
        //public IDeptInterface DepartmentRepositry { get; set; }

        IGenericInterface<T> Repo<T>() where T:ModelBase;

        int complete();
    }
}
