using ConsoleProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Command
    {
        //public IRepository<Auction> repository = new AuctionRepository();
        //public IRepository<Goods> goods_rep = new GoodRepository();
        //public IRepository<Seller> seller_rep = new SellerRepository();
        public IAuctionRepository repository = new AuctionRepository();
        public IGoodRepository goods_rep = new GoodRepository();
        public ISellerRepository seller_rep = new SellerRepository();


        public void AddAuction(Auction ac)
        {
            repository.Add(ac);
        }
        public void AddGoods(Goods gd)
        {
            goods_rep.Add(gd);
        }
        public void AddSeller(Seller sl)
        {
            seller_rep.Add(sl);
        }

        public void WriteAuction()
        {
            for (int i = 0; i < repository.GetList().Count(); i++)
            {
                repository.GetList()[i].Write();
            }
        }
        public void WriteGoods()
        {
            for (int i = 0; i < goods_rep.GetList().Count(); i++)
            {
                goods_rep.GetList()[i].Write();
            }
        }
        public void WriteSeller()
        {
            for (int i = 0; i < seller_rep.GetList().Count(); i++)
            {
                seller_rep.GetList()[i].Write();
            }
        }
        public void ChangeAct(int id)
        {
            for (int i = 0; i < repository.GetList().Count(); i++)
            {
                if(repository.GetList()[i].Id==id)
                {
                    if(repository.GetList()[i].Active == false)
                    {
                        repository.GetList()[i].Active = true;
                        repository.ChangeActive(true, id);
                    }
                    else
                    {
                        repository.GetList()[i].Active = false;
                        repository.ChangeActive(false, id);
                    }
                }
            }
        }

        public void DeleteId(int id)
        {
            goods_rep.Delete(id);
        }


        public void SortRating()
        {
            var sortedUsers = from u in seller_rep.GetList()
                              orderby u.Rating
                              select u;
            foreach (Seller u in sortedUsers)
                u.Write();
        }
    }
}
