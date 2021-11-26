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
    }
}
