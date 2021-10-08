using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public interface IGoodRepository
    {
        List<Goods> GetList();
        void ReadFromSql();
        void Add(Goods item);
        void Delete(int id);
    }
}
