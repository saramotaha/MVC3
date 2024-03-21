using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    internal interface IDeptInterface
    {

        IEnumerable<Department> GetAll();
        Department GetById(int id);
        int Add(Department d);
        int Update(Department d);
        int Delete(Department d);





    }
}
