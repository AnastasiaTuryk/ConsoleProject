using DAL;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestsAuction
{
    [TestClass]
    public class UnitTest1
    {
        public IRepository<Auction> repository = new AuctionRepository();
        public IRepository<Goods> goods_rep = new GoodsRepository();
        public IRepository<Seller> seller_rep = new SellerRepository();

        
        [TestMethod]
        public void CreateAuction()
        {
           
            var auctions = repository.GetList();

            Assert.IsTrue(auctions.Any(a => a.start_price == 1000));
        }
        [TestMethod]
        public void DeleteGoods()
        {
            var g = goods_rep.GetList();

            goods_rep.Delete(2);
            var gg = goods_rep.GetList();
            Assert.IsFalse(gg.Any(a => a.Id == 2));
        }
        [TestMethod]
        public void UpdateAuction()
        {
            var g = repository.GetList();
            repository.Update("Auction", 4, "true", "active");
            Auction actual = g.Find(a => a.Id == 4);

            Assert.IsTrue(actual.Active==true);
        }
        [TestMethod]
        public void UpdateRatingSeller()
        {
            var s = seller_rep.GetList();
            seller_rep.Update("Seller", 1, "5", "rating");
            Seller actual = s.Find(a => a.Id == 1);

            Assert.IsTrue(actual.Rating == 5);
        }
        [TestMethod]
        public void CreateGoods()
        {
            var goods = goods_rep.GetList();
          
            Assert.IsTrue(goods.Any(a => a.Material == "Mayonaise"));
        }
        [TestMethod]
        public void CreateSeller()
        {
            var seller = seller_rep.GetList();

            Assert.IsTrue(seller.Any(a => a.Name == "fr"));
        }

        [TestMethod]
        public void DeleteAuction() 
        {
            var g = repository.GetList();

            repository.Delete(5);
            var gg = repository.GetList();
            Assert.IsFalse(gg.Any(a => a.Id == 5));
        }


    }
}