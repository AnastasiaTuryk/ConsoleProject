using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        List<T> GetList();
        void ReadFromSql();
        void Add(T newItem);
        void Update(string Table, int id, string newvalue, string Field);
        void Delete(int id);
       

    }
}
