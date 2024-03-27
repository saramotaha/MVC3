using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    public interface IEmployeeInterface:IGenericInterface<Employee>
    {
        IQueryable<Employee>  GetEmpByAddress(string address);
    }
}
