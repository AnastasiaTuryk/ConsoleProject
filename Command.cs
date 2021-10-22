using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Command
    {
        public IRepository<Auction> repository = new AuctionRepository();
        public IRepository<Goods> goods_rep = new GoodsRepository();
        public IRepository<Seller> seller_rep = new SellerRepository();
       


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
            string CommandText;
            for (int i = 0; i < repository.GetList().Count(); i++)
            {
                if(repository.GetList()[i].Id==id)
                {
                    if(repository.GetList()[i].Active == false)
                    {
                        repository.GetList()[i].Active = true;
                        
                        int actint = Convert.ToInt32(true);
                        CommandText = ($"UPDATE Auction SET active= { actint} WHERE id_auction={id}");
                        repository.Update(CommandText);
                    }
                    else
                    {
                        repository.GetList()[i].Active = false;
                        int actint = Convert.ToInt32(false);
                        CommandText = ($"UPDATE Auction SET active= { actint} WHERE id_auction={id}");
                        repository.Update(CommandText);
                    }
                }
            }
        }

        public void ChangeRating(string name,int rate)
        {
            string CommandText;
            for (int i = 0; i < seller_rep.GetList().Count(); i++)
            {
                if (seller_rep.GetList()[i].Name == name)
                {
                    seller_rep.GetList()[i].Rating = rate;
           
                    CommandText = ($"UPDATE Seller SET rating= { rate} WHERE name={name}");
                    seller_rep.Update(CommandText);
                    
                }
            }
        }
        public void ChangeName(string name, int id)
        {
            string CommandText;
            for (int i = 0; i < goods_rep.GetList().Count(); i++)
            {
                if (goods_rep.GetList()[i].Id == id)
                {
                    goods_rep.GetList()[i].Name = name;

                    CommandText = ($"UPDATE Goods SET name= { name} WHERE id={id}");
                    goods_rep.Update(CommandText);

                }
            }
        }

        public void DeleteId(int id)
        {
            goods_rep.Delete(id);
        }
        public void DeleteIdSeller(int id)
        {
            seller_rep.Delete(id);
        }
        public void DeleteIdAuction(int id)
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
