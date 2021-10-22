using ConsoleProject;
using DAL;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AuctionTests
{
    [TestClass]
    public class UnitTest1
    {
        public IRepository<Auction> repository = new AuctionRepository();
        public IRepository<Goods> goods_rep = new GoodsRepository();
        public IRepository<Seller> seller_rep = new SellerRepository();

        //[TestMethod]
        //public void GetAllAuction()
        //{

              
        //}

        [TestMethod]
        public void CreateAuction()
        {
            //DateTime rowinsert = DateTime.UtcNow;
            //DateTime rowupdate = DateTime.UtcNow;
            //DateTime str1 = Convert.ToDateTime("2008-09-06");
            //DateTime str2 = Convert.ToDateTime("2010-09-06");

            //Auction r = new Auction(1, str1, str2, 100,200,false,2, rowupdate, rowinsert);
            //AuctionRepository act = new AuctionRepository();

            //act.Add(r);

            var auctions = repository.GetList();

            Assert.IsTrue(auctions.Any(a=>a.start_price ==100));
        }

        //[TestMethod]
        //public void DeleteItemCheck_Return_True()
        //{
        //    DateTime rowinsert = DateTime.UtcNow;
        //    DateTime rowupdate = DateTime.UtcNow;
        //    DateTime str1 = Convert.ToDateTime("2008-09-06");
        //    DateTime str2 = Convert.ToDateTime("2010-09-06");

        //    Auction s1 = new Auction(1, str1, str2, 100, 200, false, 2, rowupdate, rowinsert);
        //    repository.Add(s1);
        //    repository.Delete(1);
        //    bool Result = repository.isExist(s1);
        //    Assert.IsFalse(Result);
        //}

        //[TestMethod]
        //public void Update()
        //{

        //}

    }
}
