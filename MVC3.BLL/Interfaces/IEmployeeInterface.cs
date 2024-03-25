using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    public interface IEmployeeInterface
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee E);
        int Update(Employee E);
        int Delete(Employee E);
    }
}
