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
        public void ChangeAct()
        {
            
            Console.WriteLine("Type id:");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < repository.GetList().Count(); i++)
            {
                if(repository.GetList()[i].Id==id)
                {
                    if(repository.GetList()[i].Active == false)
                    {
                        repository.GetList()[i].Active = true;


                        string val = Convert.ToString(Convert.ToInt32(true));
                        repository.Update("Auction",id,val,"active");
                    }
                    else
                    {
                        repository.GetList()[i].Active = false;
                        string val = Convert.ToString(Convert.ToInt32(false));
                        repository.Update("Auction", id, val, "active");
                    }
                }
            }
        }

        public void ChangeRating()
        {
            int id;string name;int rate; Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input name:"); name = Console.ReadLine();
            Console.WriteLine("input new rate:"); rate = Convert.ToInt32(Console.ReadLine()); 
            for (int i = 0; i < seller_rep.GetList().Count(); i++)
            {
                if (seller_rep.GetList()[i].Name == name)
                {
                    seller_rep.GetList()[i].Rating = rate;
                    string r = Convert.ToString(rate);
           
                   
                    seller_rep.Update("Seller",id,r,"rating");
                    
                }
            }
        }
        public void ChangeName()
        {
          
            Console.WriteLine("Type id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("type name:");
            string name = Console.ReadLine();
            for (int i = 0; i < goods_rep.GetList().Count(); i++)
            {
                if (goods_rep.GetList()[i].Id == id)
                {
                    goods_rep.GetList()[i].Name = name;

                   
                    goods_rep.Update("Goods",id,name,"name");

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
