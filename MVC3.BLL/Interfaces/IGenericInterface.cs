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
        void Add(T d);
        void Update(T d);
        void Delete(T d);
    }
}
