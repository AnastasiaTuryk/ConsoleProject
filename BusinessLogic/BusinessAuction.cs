using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BusinessAuction
    {
        IRepository<Auction> repository = new AuctionRepository();
       
        public List<Auction> GetAllAuctions()
        {
            return repository.GetList();
        }
        public void AddAuction(int goodid, int startprice, int endpri, DateTime dateTime)
        {
            
            
            Auction auction = new Auction(0,DateTime.Now,dateTime,startprice,endpri,true,goodid,DateTime.Now,DateTime.Now);
            repository.Add(auction);
        }



        public List<Auction> ActiveAuction()
        {
            List<Auction> auctions=new List<Auction>();
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if(repository.GetList()[i].Active==true)
                {
                    auctions.Add(repository.GetList()[i]);
                }
            }
            return auctions;
        }

        public List<Auction> DisactiveAuction()
        {
            List<Auction> auctions = new List<Auction>();
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if (repository.GetList()[i].Active == false)
                {
                    auctions.Add(repository.GetList()[i]);
                }
            }
            return auctions;
        }
        public void DeactiveAuction(int id)
        {
            foreach(Auction auction in repository.GetList())
            {
                if (auction.Id == id)
                {
                    auction.Active = false;
                }
            }
        }
        public void ActivateAuction(int id)
        {
            foreach (Auction auction in repository.GetList())
            {
                if (auction.Id == id)
                {
                    auction.Active = true;
                }
            }
        }
    }
}
