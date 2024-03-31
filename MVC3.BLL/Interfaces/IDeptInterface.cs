using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    public interface IDeptInterface
    {

        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department d);
        void Update(Department d);
        void Delete(Department d);





    }
}
