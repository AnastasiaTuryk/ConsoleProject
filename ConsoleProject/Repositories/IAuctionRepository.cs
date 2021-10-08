using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public interface IAuctionRepository
    {
        List<Auction> GetList();
        void ReadFromSql();
        void Add(Auction item);
        void ChangeActive(bool act, int id);
    }
}
