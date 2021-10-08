using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public interface ISellerRepository
    {
        List<Seller> GetList();
        void ReadFromSql();
        void Add(Seller item);
        
    }
}
