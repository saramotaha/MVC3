using MVC3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.BLL.Interfaces
{
    public interface IGenericInterface<T> where T : ModelBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T d);
        int Update(T d);
        int Delete(T d);
    }
}
