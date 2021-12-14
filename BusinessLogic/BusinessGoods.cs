using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BusinessGoods
    {
        public IRepository<Goods> repository = new GoodsRepository();
        public List<Goods> Search(string name)
        {
            List<Goods> searchedgoods = new List<Goods>();
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if(repository.GetList()[i].Name==name)
                {
                    searchedgoods.Add(repository.GetList()[i]);
                }
            }
            return searchedgoods;
        }
        public List<Goods> GetAllGoods()
        {
            return repository.GetList();
        }
        public List<Goods> SortGoods()
        {
            List<Goods> list=new List<Goods>();
            List<Goods> goods = repository.GetList();
            var sortedGoods = from u in goods
                              orderby u.RowInsertTime
                              select u;
            foreach (Goods u in sortedGoods)
            {
                list.Add(u);
            }
            return list;
              
        }
    }

    
}
